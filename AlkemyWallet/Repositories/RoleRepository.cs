using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(WalletDbContext context)
        : base(context)
    {
    }

    public async Task<bool> ExistRolByName(string rolName)
    {
        var rol = await _context.Roles!.FirstOrDefaultAsync(u => u.Name.Equals(rolName))!;
        if (rol is not null)
            return true;
        return false;
    }
}