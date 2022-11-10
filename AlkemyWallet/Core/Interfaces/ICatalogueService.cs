using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Entities.Paged;

namespace AlkemyWallet.Core.Interfaces;

public interface ICatalogueService
{
    Task<bool> DeleteCatalogue(int id);
    Task<IEnumerable<Catalogue>> GetCatalogues();
    Task<Catalogue> GetCatalogueById(int id);
    Task<IEnumerable<Catalogue>> GetCatalogueByPoints(int points);
    Task InsertCatalogue(CatalogueForCreationDTO catalogue);
    Task<bool> UpdateCatalogues(int id, CatalogueForUpdateDTO CatalogueDTO);
    PagedList<Catalogue> GetCataloguePages(PageResourceParameters pageResourceParameters);
}