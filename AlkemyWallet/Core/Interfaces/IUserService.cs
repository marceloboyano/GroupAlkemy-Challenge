using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
    }
}
