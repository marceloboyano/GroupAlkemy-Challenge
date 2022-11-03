using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Core.Models.DTO;


namespace AlkemyWallet.Core.Interfaces
{
    public interface ICatalogueService
    {
        Task<IEnumerable<Catalogue>> GetCatalogues();
        Task<Catalogue> GetCatalogueById(int id);
    }
}