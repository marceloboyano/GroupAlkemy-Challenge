using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services
{
    public class RoleService :IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await _unitOfWork.RoleRepository.GetAll();
            return roles;
        }
        public async Task<Role> GetRoleById(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetById(id);
            return role;
        }
        public async Task AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await _unitOfWork.RoleRepository.Insert(role);
        }
        public async Task<bool> UpdateRole(int id, RoleForUpdateDTO roleDTO)
        {
            var roleEntity = await _unitOfWork.RoleRepository.GetById(id);
            if(roleEntity != null)
            {
                roleEntity.Name = roleDTO.Name;
                roleEntity.Description = roleDTO.Description;
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteRole(int id)
        {
            await _unitOfWork.RoleRepository.Delete(id);
            return true;
        }
    }
}
