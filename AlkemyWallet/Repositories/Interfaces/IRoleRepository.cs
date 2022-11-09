using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IRoleRepository : IRepositoryBase<Role>
{
    Task<bool> ExistRolByName(string rolName);
}