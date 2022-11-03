using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface ICatalogueService
    {
        Task<IEnumerable<Catalogue>> GetCatalogues();
        Task<Catalogue> GetCatalogueById(int id);
    }
}