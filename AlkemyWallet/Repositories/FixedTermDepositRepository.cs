using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class FixedTermDepositRepository : RepositoryBase<FixedTermDeposit>, IFixedTermDepositRepository
{
    public FixedTermDepositRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<FixedTermDeposit>> GetByUser(int userId) => await _context.Set<FixedTermDeposit>()
               .Where(u => u.User_id == userId)
               .OrderByDescending(d => d.Creation_date)
               .ToListAsync();



    public async Task<FixedTermDeposit?> GetFixedTermById(int id, int userId) => await _context.Set<FixedTermDeposit>()            
            .Where(t => t.Id == id && t.User_id == userId)
            .FirstOrDefaultAsync();            
           
   

    public async Task<(int totalPages, IEnumerable<FixedTermDeposit> recordList)> GetFixedTermDepositsPaging(int userId, int pageNumber, int pageSize)
    {
        var list = await _context.Set<FixedTermDeposit>()            
            .Where(t => t.User_id == userId)
            .OrderBy(x => x.Creation_date)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalRecords = _context.Set<FixedTermDeposit>()
            .Where(t => t.User_id == userId)
            .Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }
}