using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IFixedTermDepositService
    {
        Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits();
        Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int id);
    }
}
