using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace AlkemyWallet.Core.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllUser()
    {
        var users = await _unitOfWork.UserRepository.GetAll();
        users = users.OrderBy(x => x.First_name);
        return users;
    }

    public async Task<User> GetById(int id)
    {
        var user = await _unitOfWork.UserDetailsRepository.GetById(id);
        return user;
    }

    public async Task<string> AddUser(UserForCreatoionDto userDTO)
    {
        bool isValidEmailValid = IsEmailValid(userDTO.Email);
        if (isValidEmailValid)
        {
            bool emailExist = _unitOfWork.UserDetailsRepository!.GetUserByEmail(userDTO.Email).Result;
            if (emailExist)
                return $"Ya se encuentra registrado el email {userDTO.Email} en la base de datos";
            else
            {
                User user = _mapper.Map<User>(userDTO);
                user.Rol_id = 2;
                user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                await _unitOfWork.UserRepository!.Insert(user);
                await _unitOfWork.SaveChangesAsync();
                return "Se agregó con exito";
            }
        }
        else
            return "El email no cumple con los parámetros requeridos";
    }

    public async Task<bool> UpdateUser(int id, UserForUpdateDto userDTO)
    {
        User userEntity = await _unitOfWork.UserRepository!.GetById(id);
        if (userEntity is not null)
        {
            userEntity.First_name = string.IsNullOrEmpty(userDTO.First_name) ? userEntity.First_name : userDTO.First_name;
            userEntity.Last_name = string.IsNullOrEmpty(userDTO.Last_name) ? userEntity.Last_name : userDTO.Last_name;
            userEntity.Rol_id = userDTO.Rol_id.Equals(0) ? userEntity.Rol_id : userDTO.Rol_id;
            userEntity.Password = string.IsNullOrEmpty(userDTO.Password) ? userEntity.Password : BCrypt.Net.BCrypt.HashPassword(userDTO.Password); 
            userEntity.Points = userDTO.Points;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        else
            return false;   
    }

    public async Task<bool> DeleteUser(int id)
    {
        User deleteUser = await _unitOfWork.UserRepository!.GetById(id);
        if (deleteUser is null)
            return false;

        await _unitOfWork.UserRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    private static bool IsEmailValid(string email)
    {
        Regex regex = new("^[_a-z0-9A-Z]+(\\.[_a-z0-9A-Z]+)*@[a-zA-Z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-zA-Z]{2,15})$");
        if (regex.IsMatch(email))
            return true;
        else
            return false;
    }
}