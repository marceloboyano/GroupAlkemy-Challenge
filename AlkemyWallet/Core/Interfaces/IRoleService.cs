using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRoleById(int id);
    Task<string> AddRole(RoleDTO roleDTO);
    Task<bool> UpdateRole(int id, RoleForUpdateDTO roleDTO);
    Task<bool> DeleteRole(int id);
}