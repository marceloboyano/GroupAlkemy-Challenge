using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(WalletDbContext context)
            : base(context)
        {

        }


    }
}

