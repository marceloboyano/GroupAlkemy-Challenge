using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Core.Services
{
    public class UserService : IUserService
    {
        private readonly WalletDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, WalletDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }
        public Task<User> GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }
        public async Task<User> AddUser(User user)
        {
            if(user.Role != null)
            {
                _dbContext.Entry(user.Role).State = EntityState.Unchanged;
            }
           var AddUser = await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.SaveChangesAsync();
            return AddUser;
            
        }
        public async Task<User> UpdateUser(User user)
        {
            var userUpdate = await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return userUpdate;
        }
        public async Task DeleteUser(int id)
        {
            var userId = await _unitOfWork.UserRepository.GetById(id);
            if(userId != null)
            {
              await _unitOfWork.UserRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
           
        }
    }
}
