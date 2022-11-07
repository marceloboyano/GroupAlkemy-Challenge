using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<Account?> GetByIdWithDetail(int accountId)
    {
        return await _context.Accounts
            .Include(a => a.User)
            .FirstOrDefaultAsync(m => m.Id == accountId);
    }
}