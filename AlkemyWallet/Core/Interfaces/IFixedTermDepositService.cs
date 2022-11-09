using AlkemyWallet.Core.Helper;
using AlkemyWallet.Entities;
using AlkemyWallet.Entities.Paged;

namespace AlkemyWallet.Core.Interfaces;

public interface IFixedTermDepositService
{
    Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits();
    Task<FixedTermDeposit> GetFixedTermDepositsById(int id);
    Task<bool> DeleteFixedTermDeposit(int id);
    PagedList<FixedTermDeposit> GetFixedPaged(PageResourceParameters pageResourceParameters);
}