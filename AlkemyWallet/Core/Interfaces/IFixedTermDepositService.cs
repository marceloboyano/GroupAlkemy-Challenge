using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface IFixedTermDepositService
{
    Task<FixedTermDeposit> GetFixedTermDepositsById(int id, int userId);
    Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int id);
    Task<bool> DeleteFixedTermDeposit(int id);
    Task<bool> UpdateDeposit(int id, DepositForUpdateDTO depositDTO);
    Task InsertFixedTermDeposit(DepositForCreationDTO depositDTO);
}