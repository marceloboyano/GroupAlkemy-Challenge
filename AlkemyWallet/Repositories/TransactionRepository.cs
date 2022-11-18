using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> GetByUser(int userId) => await _context.Set<Transaction>().Where(t => t.User_id == userId).OrderBy(x => x.Date).ToListAsync();



    public async Task<(int totalPages, IEnumerable<Transaction> recordList)> GetByUserPaging(int userId, int pageNumber,
        int pageSize)
    {
        var list = await Task.FromResult(_context.Set<Transaction>()
            .Where(t => t.User_id == userId)
            .OrderBy(x => x.Date)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable());
        var totalRecords = _context.Set<Transaction>()
            .Where(t => t.User_id == userId)
            .Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }
}