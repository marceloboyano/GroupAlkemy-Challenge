using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(WalletDbContext context)
            : base(context)
        {

        }


    }
}
