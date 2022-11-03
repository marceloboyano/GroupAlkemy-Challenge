using AlkemyWallet.Core.Models;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
