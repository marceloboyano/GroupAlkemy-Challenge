using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IFixedTermDepositService
    {
        Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits();
        Task<FixedTermDeposit> GetFixedTermDepositsById(int id);
        Task<bool> DeleteFixedTermDeposit(int id);



    }
}
