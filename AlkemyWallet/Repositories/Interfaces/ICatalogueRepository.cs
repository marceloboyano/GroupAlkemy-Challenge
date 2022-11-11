using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface ICatalogueRepository : IRepositoryBase<Catalogue>
{
    Task<IEnumerable<Catalogue>> GetByPoints(int points);
}