using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;

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

