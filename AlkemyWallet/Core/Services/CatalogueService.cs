using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AlkemyWallet.Repositories;

namespace AlkemyWallet.Core.Services
{
    public class CatalogueService : ICatalogueService
    { 
        private readonly IUnitOfWork _unitOfWork;

        public CatalogueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Catalogue> GetCatalogueById(int id)
        {
            var catalogue = await _unitOfWork.CatalogueRepository.GetById(id);            
            return catalogue;
        }

        public async Task<IEnumerable<Catalogue>> GetCatalogues()
        {
            var catalogues = await _unitOfWork.CatalogueRepository.GetAll();
            catalogues = catalogues.OrderBy(x => x.Points);
            return catalogues;
        }
    }
}
