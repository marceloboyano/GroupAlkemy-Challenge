using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IFixedTermDepositRepository : IRepositoryBase<FixedTermDeposit>
{
    Task<IEnumerable<FixedTermDeposit>> GetByUser(int userId);
    Task<FixedTermDeposit?> GetFixedTermById(int id, int userId);
    Task<(int totalPages, IEnumerable<FixedTermDeposit> recordList)> GetFixedTermDepositsPaging(int userId, int pageNumber, int pageSize);
}