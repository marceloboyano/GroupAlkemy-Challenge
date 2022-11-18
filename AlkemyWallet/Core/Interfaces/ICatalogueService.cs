using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface ICatalogueService
{
    Task<bool> DeleteCatalogue(int id);
    Task<IEnumerable<Catalogue>> GetCatalogues();
    Task<Catalogue?> GetCatalogueById(int id);
    Task<IEnumerable<Catalogue>> GetCatalogueByPoints(int userId);
    Task InsertCatalogue(CatalogueForCreationDTO catalogue);
    Task<bool> UpdateCatalogues(int id, CatalogueForUpdateDTO catalogueDTO);
    Task<(int totalPages, IEnumerable<Catalogue> recordList)> GetCataloguesPaging(int pageNumber, int pageSize);
}