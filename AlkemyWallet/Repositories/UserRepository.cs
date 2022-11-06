using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
        {
            public UserRepository(WalletDbContext context)
                : base(context)
            {

            }

            public async Task<IEnumerable<User>> GetUserWithDetails(int id)
            { 
                 return await Task.FromResult(_context.Set<User>().Where(t => t.Id == id)
                .Include(a=>a.Account)
                .AsEnumerable());
            }
        }
}

