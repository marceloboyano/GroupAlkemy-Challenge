using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBase<Transaction>
{
    Task<IEnumerable<Transaction>> GetByUser(int userId);

    Task<(int totalPages, IEnumerable<Transaction> recordList)> GetByUserPaging(int userId, int pageNumber,
        int pageSize);
}