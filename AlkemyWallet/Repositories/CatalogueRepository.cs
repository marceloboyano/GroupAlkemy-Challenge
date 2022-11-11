using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class CatalogueRepository : RepositoryBase<Catalogue>, ICatalogueRepository
{
    public CatalogueRepository(WalletDbContext context)
        : base(context)
    {
    }
    public async Task<IEnumerable<Catalogue>> GetByPoints(int points)
    {
        return await Task.FromResult(_context.Set<Catalogue>().Where(t => t.Points <= points).AsEnumerable());
    }
}