using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface ICatalogueService
    {
        Task<bool> DeleteCatalogue(int id);
        Task<IEnumerable<Catalogue>> GetCatalogues();
        Task<Catalogue> GetCatalogueById(int id);
        Task InsertCatalogue(CatalogueForCreationDTO catalogue);
    }
}