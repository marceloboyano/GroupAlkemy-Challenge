using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            return user;
        }
        
    }
}
