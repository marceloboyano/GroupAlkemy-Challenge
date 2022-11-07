using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task<Account?> GetByIdWithDetail(int accountId);
}