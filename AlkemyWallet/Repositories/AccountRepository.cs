using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AlkemyWallet.DataAccess;
namespace AlkemyWallet.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(WalletDbContext context)
            : base(context)
        {

        }


    }
}

