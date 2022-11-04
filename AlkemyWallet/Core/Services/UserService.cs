using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
<<<<<<< HEAD
using AlkemyWallet.Repositories.Interfaces;
=======
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
>>>>>>> dev
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Core.Services
{
    public class UserService : IUserService
    {
<<<<<<< HEAD
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
=======
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            users = users.OrderBy(x=>x.First_name);
            return users;
        }
        public async Task<User> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            return user;
        }
        public async Task AddUser(UserForCreatoionDto userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
           await _unitOfWork.UserRepository.Insert(user);
        }
        public async Task<bool> UpdateUser(int id,UserForUpdateDto userDTO)
        {
            var userEntity = await _unitOfWork.UserRepository.GetById(id);
            if (userEntity != null)
            {
                userEntity.First_name = userDTO.First_name;
                userEntity.Last_name = userDTO.Last_name;
                userEntity.Rol_id = userDTO.Rol_id;

                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return true;
           
        }
        
>>>>>>> dev
    }
}
