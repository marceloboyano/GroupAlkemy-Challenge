using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services;

public class FixedTermDepositService : IFixedTermDepositService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public FixedTermDepositService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<FixedTermDeposit?> GetFixedTermDepositsById(int id, int userId)
    {
        var fixedTermDepositsEntity = await _unitOfWork.FixedTermDepositRepository!.GetFixedTermById(id, userId);
        return fixedTermDepositsEntity;
    }

    public async Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int userId)
    {
        var fixedTermDepositsByUserId = await _unitOfWork.FixedTermDepositRepository!.GetByUser(userId);
        fixedTermDepositsByUserId = fixedTermDepositsByUserId.OrderBy(x => x.Creation_date);
        return fixedTermDepositsByUserId;
    }


    public async Task<bool> DeleteFixedTermDeposit(int id)
    {
        await _unitOfWork.FixedTermDepositRepository!.Delete(id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateDeposit(int id, DepositForUpdateDTO depositDTO)
    {
        var depositEntity = await _unitOfWork.FixedTermDepositRepository!.GetById(id);

        if (depositEntity is null)
            return false;

        if (depositDTO.User_id is not null)
            depositEntity.User_id = depositDTO.User_id.Value;

        if (depositDTO.Account_id is not null)
            depositEntity.Account_id = depositDTO.Account_id.Value;

        if (depositDTO.Amount is not null)
            depositEntity.Amount = depositDTO.Amount.Value;

        if (depositDTO.Creation_date is not null)
            depositEntity.Creation_date = depositDTO.Creation_date.Value;

        if (depositDTO.Closing_date is not null)
            depositEntity.Closing_date = depositDTO.Closing_date.Value;


        await _unitOfWork.FixedTermDepositRepository.Update(depositEntity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }


    public async Task InsertFixedTermDeposit(DepositForCreationDTO depositDTO)
    {
        var deposit = _mapper.Map<FixedTermDeposit>(depositDTO);
        deposit.Creation_date = DateTime.Now;
        await _unitOfWork.FixedTermDepositRepository!.Insert(deposit);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<(int totalPages, IEnumerable<FixedTermDeposit> recordList)> GetFixedTermDepositsPaging(int userId, int pageNumber, int pageSize)
    {
        return await _unitOfWork.FixedTermDepositRepository!.GetFixedTermDepositsPaging(userId, pageNumber, pageSize);
    }
}