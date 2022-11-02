using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories
{
    public class FixedTermDepositRepository : RepositoryBase<FixedTermDeposit>, IFixedTermDepositRepository
    {
        public FixedTermDepositRepository(WalletDbContext context)
            : base(context)
        {

        }


    }
}

