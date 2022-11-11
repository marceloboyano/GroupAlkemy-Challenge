using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class FixedTermDepositRepository : RepositoryBase<FixedTermDeposit>, IFixedTermDepositRepository
{
    public FixedTermDepositRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<FixedTermDeposit>> GetByUser(int userId)
    {
        return await Task.FromResult(_context.Set<FixedTermDeposit>().Where(t => t.User_id == userId).AsEnumerable());
    }

    public async Task<FixedTermDeposit?> GetFixedTermById(int id, int userId)
    {
        return await Task.FromResult(_context.Set<FixedTermDeposit>().Where(t => t.Id == id && t.User_id == userId)
            .FirstOrDefault());
    }

    public async Task<(int totalPages, IEnumerable<FixedTermDeposit> recordList)> GetFixedTermDepositsPaging(int userId, int pageNumber, int pageSize)
    {
        var list = await Task.FromResult(_context.Set<FixedTermDeposit>()
            .Where(t => t.User_id == userId)
            .OrderBy(x => x.Creation_date)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable());
        var totalRecords = _context.Set<FixedTermDeposit>()
            .Where(t => t.User_id == userId)
            .Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }
}