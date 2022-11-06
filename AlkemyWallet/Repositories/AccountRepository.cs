using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AlkemyWallet.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace AlkemyWallet.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(WalletDbContext context)
            : base(context)
        {

        }
        public async Task<Account?> GetByIdWithDetail(int accountId) => await _context.Accounts
          .Include(a => a.User)
          .FirstOrDefaultAsync(m => m.Id == accountId);
        
        

    }
}

