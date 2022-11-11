using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<User> GetUserByEmail(string email, string password)
    {
        var user = await _context.Users!.FirstOrDefaultAsync(u => u.Email.Equals(email));
        if (user is not null && !BCrypt.Net.BCrypt.Verify(password, user!.Password))
            return user = null!;

        return user;
    }

    public async Task<bool> GetUserByEmail(string email)
    {
        var user = await _context.Users!.FirstOrDefaultAsync(u => u.Email.Equals(email))!;
        if (user is not null)
            return true;
        return false;
    }

    public async Task<User?> GetUserWithDetails(int id)
    {
        return await Task.FromResult(_context.Set<User>()
            .Include(a => a.Account)
            .Include(r => r.Role)
            .Include(f => f.FixedTermDeposit)
            .FirstOrDefault(x => x.Id == id));
    }
}