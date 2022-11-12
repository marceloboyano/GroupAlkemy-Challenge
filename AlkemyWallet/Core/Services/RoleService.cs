using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using static AlkemyWallet.Core.Helper.Constants;

namespace AlkemyWallet.Core.Services;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _roleRepository = roleRepository;
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

    public async Task<string> AddRole(RoleDTO roleDTO)
    {
        var existEmail = await _roleRepository.ExistRolByName(roleDTO.Name);
        if (existEmail)
        {
            return ROL_REGISTERED_MESSAGE;
        }

        var role = _mapper.Map<Role>(roleDTO);
        await _unitOfWork.RoleRepository!.Insert(role);
        await _unitOfWork.SaveChangesAsync();
        return ROL_SUCCESSFUL_ADDED_MESSAGE;
    }

    public async Task<bool> UpdateRole(int id, RoleForUpdateDTO roleDTO)
    {
        var roleEntity = await _unitOfWork.RoleRepository!.GetById(id);
        if (roleEntity is not null)
        {
            roleEntity.Name = roleDTO.Name;
            roleEntity.Description = roleDTO.Description;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteRole(int id)
    {
        await _unitOfWork.RoleRepository.Delete(id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}