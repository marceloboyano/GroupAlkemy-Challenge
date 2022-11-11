using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUser();
    Task<User?> GetById(int id);
    Task<string> AddUser(UserForCreatoionDto userDTO);
    Task<bool> UpdateUser(int id, UserForUpdateDto userDTO);
    Task<bool> DeleteUser(int id);
    Task<(bool Success, string Message)> Exchange(int id, string userIdFromToken);
    Task<(int totalPages, IEnumerable<User> recordList)> GetUsersPaging(int pageNumber, int pageSize);
}