using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using static AlkemyWallet.Core.Helper.Constants;

namespace AlkemyWallet.Core.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Account>> GetAccounts()
    {
        var accounts = await _unitOfWork.AccountRepository!.GetAll();
        return accounts;
    }

    public async Task<Account?> GetAccountById(int id)
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
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<(bool Success, string Message)> DeleteAccount(int id)
    {
        var fixedTermEntity = await _unitOfWork.FixedTermDepositRepository!.GetById(id);
        if (fixedTermEntity is not null)
            return (Success: false, Message: ACC_PENDING_TRANSACTIONS_MESSAGE);
        await _unitOfWork.AccountRepository!.Delete(id);
        if (await _unitOfWork.SaveChangesAsync() > 0)
            return (true, Message: ACC_DELETED_MESSAGE);
        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(bool Success, string Message)> Deposit(int id, int amount)
    {
        if (amount <= 0) return (false, Message: ACC_AMOUNT_LESS_THAN_ZERO_MESSAGE);

        var account = await _unitOfWork.AccountWithDetails!.GetByIdWithDetail(id);

        if (account is null)
            return (false, Message: ACC_NOT_FOUND_MESSAGE);
        if (account.IsBlocked)
            return (false, Message: ACC_BLOCK_MESSAGE);

        //se suman los puntos al usuario un 2% redondeado en el deposito
        account.Money += amount;
        var porcentaje = amount * 2m / 100m;
        porcentaje = Math.Round(porcentaje);
        account.User!.Points += Convert.ToInt32(porcentaje);

        var transaction = new Transaction
        {
            Amount = amount,
            Concept = "Deposit",
            Date = DateTime.Now,
            Type = "Topup",
            User_id = id,
            Account_id = account.Id
        };

        await _unitOfWork.TransactionRepository!.Insert(transaction);


        await _unitOfWork.AccountRepository!.Update(account);

        if (await _unitOfWork.SaveChangesAsync() > 0)
            return (Success: true, Message: ACC_DELETED_MESSAGE);
        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(bool Success, string Message)> Transfer(int id, int amount, int toAccountId)
    {
        if (amount <= 0) return (Success: false, Message: ACC_AMOUNT_LESS_THAN_ZERO_MESSAGE);


        //traigo el usuario que transfiere el dinero
        var account = await _unitOfWork.AccountWithDetails!.GetByIdWithDetail(id);

        if (account is null)
            return (Success: false, Message: ACC_NOT_FOUND_MESSAGE);
        if (account.IsBlocked)
            return (Success: false, Message: ACC_BLOCK_MESSAGE);
        if (account.Money < amount)
            return (Success: false, Message: ACC_INSUFFICIENT_FUNDS_MESSAGE);
        account.Money -= amount;
        var porcentaje = amount * 3m / 100m;
        porcentaje = Math.Round(porcentaje);
        account.User!.Points += Convert.ToInt32(porcentaje);
        if (id == toAccountId)
            return (Success: false, Message: ACC_SAME_ACCOUNT_MESSAGE);

        //traigo el usuario que recibe el dinero
        var toAccount = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(toAccountId);
        if (toAccount is null)
            return (Success: false, Message: ACC_NOT_FOUND_MESSAGE);
        if (toAccount.IsBlocked)
            return (Success: false, Message: ACC_BLOCK_MESSAGE);
        toAccount.Money += amount;

        var transaction = new Transaction
        {
            Amount = amount,
            Concept = "transfer",
            Date = DateTime.Now,
            Type = "Payment",
            User_id = id,
            Account_id = account.Id,
            To_Account = toAccountId
        };

        await _unitOfWork.TransactionRepository!.Insert(transaction);
        await _unitOfWork.AccountRepository!.Update(account);
        await _unitOfWork.AccountRepository.Update(toAccount);

        if (await _unitOfWork.SaveChangesAsync() > 0)
            return (Success: true, Message: ACC_TRANSFER_SUCCESSFUL_MESSAGE);
        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(bool Success, string Message)> Block(int id)
    {
        var accountEntity = await _unitOfWork.AccountRepository!.GetById(id);

        if (accountEntity is null)
            return (Success: false, Message: ACC_NOT_FOUND_MESSAGE);

        if (accountEntity.IsBlocked)
            return (Success: false, Message: ACC_BLOCK_MESSAGE);

        accountEntity.IsBlocked = true;

        await _unitOfWork.AccountRepository!.Update(accountEntity);
        if (await _unitOfWork.SaveChangesAsync() > 0)
            return (Success: true, Message: ACC_BLOCK_SUCCESSFUL_MESSAGE);
        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(bool Success, string Message)> Unblock(int id)
    {
        var accountEntity = await _unitOfWork.AccountRepository!.GetById(id);

        if (accountEntity is null)
            return (Success: false, Message: ACC_NOT_FOUND_MESSAGE);

        if (!accountEntity.IsBlocked)
            return (Success: false, Message: ACC_BLOCK_MESSAGE);

        accountEntity.IsBlocked = false;

        await _unitOfWork.AccountRepository!.Update(accountEntity);
        if (await _unitOfWork.SaveChangesAsync() > 0) return (Success: true, Message: ACC_UNBLOCK_SUCCESSFUL_MESSAGE);
        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(int totalPages, IEnumerable<Account> recordList)> GetAccountsPaging(int pageNumber, int pageSize)
    {
        return await _unitOfWork.AccountRepository!.GetAllPaging(pageNumber, pageSize);
    }
}