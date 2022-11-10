using AlkemyWallet.Core.Helper;
using AlkemyWallet.Entities;
using AlkemyWallet.Entities.Paged;


namespace AlkemyWallet.Core.Interfaces;

public interface IFixedTermDepositService
{
    Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits();
    Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int id);
    Task<bool> DeleteFixedTermDeposit(int id);
    PagedList<FixedTermDeposit> GetPagedFtD(PageResourceParameters pageResourceParameters);
}

