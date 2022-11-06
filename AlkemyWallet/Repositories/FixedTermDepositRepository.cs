using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AlkemyWallet.DataAccess;
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

