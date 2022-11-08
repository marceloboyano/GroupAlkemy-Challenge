using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> GetByUser(int userId)
    {
        return await Task.FromResult(_context.Set<Transaction>().Where(t => t.User_id == userId).AsEnumerable());
    }
    public override async Task Insert(Transaction entity)
    {
        await base.Insert(entity);
    }

     private async Task<bool> ValidateTransaction(Transaction transaction)
        {
            IAccountService accountService = new AccountService(_unitOfWork, null, null);
            Account account = await accountService.GetAccountById(transaction.Account_id);
            if((account == null) || (account.User_id!=transaction.User_id) ) return false;

            IUserService userService = new UserService(_unitOfWork, null);
            User user = await userService.GetById(transaction.User_id);
            if(user == null) return false;

            return true;
        }
}
