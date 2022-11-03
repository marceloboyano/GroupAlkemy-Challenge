<<<<<<< HEAD
﻿using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
=======
using AlkemyWallet.Core.Interfaces;
>>>>>>> 7c3f4e3a649b0593ccb23ea1491ce8771704ba86
using AlkemyWallet.Entities;
using AlkemyWallet.Core.Models.DTO;


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