using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBase<Transaction>
{
    Task<IEnumerable<Transaction>> GetByUser(int userId);
    Task<IEnumerable<Transaction>> GetByUserPaging(int userId, int pageNumber, int pageSize);
}