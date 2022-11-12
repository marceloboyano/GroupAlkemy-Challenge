using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface ICatalogueRepository : IRepositoryBase<Catalogue>
{
    Task<IEnumerable<Catalogue>> GetByPoints(int points);
    Task<(int totalPages, IEnumerable<Catalogue> recordList)> GetCataloguesPaging(int pageNumber, int pageSize);
}