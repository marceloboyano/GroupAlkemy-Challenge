using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AlkemyWallet.DataAccess;
namespace AlkemyWallet.Repositories
{
    public class CatalogueRepository : RepositoryBase<Catalogue>, ICatalogueRepository
    {
        public CatalogueRepository(WalletDbContext context)
            : base(context)
        {

        }


    }
}

