using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class CatalogueRepository : RepositoryBase<Catalogue>, ICatalogueRepository
{
    public CatalogueRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Catalogue>> GetByPoints(int points) => await _context.Set<Catalogue>()
            .Where(t => t.Points <= points)
            .OrderBy(x => x.Points)
            .ToListAsync();





    public async Task<(int totalPages, IEnumerable<Catalogue> recordList)> GetCataloguesPaging(int pageNumber,
        int pageSize)
    {
        var list = await _context.Set<Catalogue>()             
            .OrderBy(x => x.Points)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalRecords = _context.Set<Catalogue>().AsEnumerable().Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }
}