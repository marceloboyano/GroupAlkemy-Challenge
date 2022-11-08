using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using static challenge.Services.ImageService;

namespace AlkemyWallet.Core.Services;

public class AccountService : IAccountService
{
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<IEnumerable<Account>> GetAccounts()
    {
        var accounts = await _unitOfWork.AccountRepository!.GetAll();
        return accounts;
    }

    public async Task<Account> GetAccountById(int id)
    {
        var account = await _unitOfWork.AccountRepository!.GetById(id);
        return account;
    }

    public async Task InsertAccounts(AccountForCreationDTO accountDTO)
    {
        
             
        var account = _mapper.Map<Account>(accountDTO);  
        await _unitOfWork.AccountRepository!.Insert(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UpdateAccount(int id, AccountForUpdateDTO accountDTO)
    {
        var accountEntity = await _unitOfWork.AccountRepository!.GetById(id);

        if (accountEntity is null)
            return false;

        if (accountDTO.User_id is not null) accountEntity.User_id = accountDTO.User_id.Value;       

        if (accountDTO.CreationDate is not null)
            accountEntity.CreationDate = (DateTime)accountDTO.CreationDate;
        if (accountDTO.Money is not null)
            accountEntity.Money = (float)accountDTO.Money;


        await _unitOfWork.AccountRepository!.Update(accountEntity);
        return await _unitOfWork.SaveChangesAsync()>0;
    }


    public async Task<(bool Success, string Message)> Deposit(int id, int amount)
    {
        //el monto ingresado debe ser mayor a 0
        if (amount > 0)
        {
            var account = await _unitOfWork.AccountWithDetails!.GetByIdWithDetail(id);

            if (account is null)
                return (false, "El id de la cuenta que ingreso no fue encontrado.");
            if (account.IsBlocked)
                return (false, "Su cuenta esta bloqueada, no puede realizar operaciones.");

            //se suman los puntos al usuario un 2% redondeado en el deposito
            account.Money += amount;
            decimal porcentaje = amount * 2m / 100m;
            porcentaje = Math.Round(porcentaje);
            account.User!.Points += Convert.ToInt32(porcentaje);

            var transaction = new Transaction()
            {
                Amount = amount,
                Concept = "Deposit",
                Date = DateTime.Now,
                Type = "Topup",
                User_id = id,
                Account_id = account.Id,
            };

            await _unitOfWork.TransactionRepository!.Insert(transaction);


            await _unitOfWork.AccountRepository!.Update(account);

            if (await _unitOfWork.SaveChangesAsync() > 0) return (true, "Deposito exitoso.");
            else return (false, "Algo ha salido mal cuando se intento guardar los cambios!!!");
        }
        else
        {
            return (false, "El importe ingresado debe ser mayor a 0");
        }

    }

    public async Task<(bool Success, string Message)> Transfer(int id, int amount, int toAccountId)
    {
        if (amount > 0)
        {

            //traigo el usuario que transfiere el dinero
            var account = await _unitOfWork.AccountWithDetails!.GetByIdWithDetail(id);

            if (account is null)
                return (false, "El id de la cuenta que ingreso no fue encontrado.");
            if (account.IsBlocked)
                return (false, "Su cuenta esta bloqueada, no puede realizar operaciones.");
            if (account.Money < amount)
                return (false, "El dinero disponible en la cuenta es menor que el importe a transferir.");
            account.Money -= amount;
            decimal porcentaje = amount * 3m / 100m;
            porcentaje = Math.Round(porcentaje);
            account.User!.Points += Convert.ToInt32(porcentaje);
            if(id == toAccountId)
                return (false, "La cuenta de destino es igual a la de origen. No se puede transferir a la misma cuenta.");

            //traigo el usuario que recibe el dinero
            var toAccount = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(toAccountId);
            if (toAccount is null)
                return (false, "La cuenta a la que desea transferir no fue encontrada.");
            if (toAccount.IsBlocked)
                return (false, "La cuenta a la que desea transferir esta bloqueada, no puede realizar operaciones.");
            toAccount.Money += amount;

            var transaction = new Transaction()
            {
                Amount = amount,
                Concept = "transfer",
                Date = DateTime.Now,
                Type = "Payment",
                User_id = id,
                Account_id = account.Id,
                To_Account = toAccountId,
            };

            await _unitOfWork.TransactionRepository!.Insert(transaction);
            await _unitOfWork.AccountRepository!.Update(account);
            await _unitOfWork.AccountRepository.Update(toAccount);

            if(await _unitOfWork.SaveChangesAsync()>0)  return (true, "Transferencia exitosa.");
            else return (false, "Algo ha salido mal cuando se intento guardar los cambios!!!");

        }
        else
        {
            return (false, "El importe ingresado debe ser mayor a 0");
        }

    }

    public async Task<(bool Success, string Message)> Block(int id)
    {
        var accountEntity = await _unitOfWork.AccountRepository!.GetById(id);

        if (accountEntity is null)
            return (false, "El id de la cuenta que ingreso no fue encontrado.");

        if (accountEntity.IsBlocked == true)
            return (false, "La cuenta que intenta bloquear ya se encuentra bloqueada.");

          accountEntity.IsBlocked = true;          

        await _unitOfWork.AccountRepository!.Update(accountEntity);
        if (await _unitOfWork.SaveChangesAsync() > 0) return (true, "La cuenta ha sido Bloqueada.");
        else return (false, "Algo ha salido mal cuando se intento guardar los cambios!!!");
    }
    public async Task<(bool Success, string Message)> Unblock(int id)
    {
        var accountEntity = await _unitOfWork.AccountRepository!.GetById(id);

        if (accountEntity is null)
            return (false, "El id de la cuenta que ingreso no fue encontrado.");

        if (accountEntity.IsBlocked == false)
            return (false, "La cuenta que intenta desbloquear ya se encuentra desbloqueada.");

        accountEntity.IsBlocked = false;

        await _unitOfWork.AccountRepository!.Update(accountEntity);
        if (await _unitOfWork.SaveChangesAsync() > 0) return (true, "La cuenta ha sido Desbloqueada.");
        else return (false, "Algo ha salido mal cuando se intento guardar los cambios!!!");
    }

}
