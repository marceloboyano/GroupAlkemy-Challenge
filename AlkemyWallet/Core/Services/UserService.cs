using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using System.Text.RegularExpressions;
using static AlkemyWallet.Core.Helper.Constants;

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
        var users = await _unitOfWork.UserRepository!.GetAll();
        users = users.OrderBy(x => x.First_name);
        return users;
    }

    public async Task<User?> GetById(int id)
    {
        var user = await _unitOfWork.UserDetailsRepository!.GetUserWithDetails(id);
        return user;
    }

    public async Task<string> AddUser(UserForCreatoionDto userDTO)
    {
        var isValidEmailValid = IsEmailValid(userDTO.Email);
        if (isValidEmailValid)
        {
            var emailExist = _unitOfWork.UserDetailsRepository!.GetUserByEmail(userDTO.Email).Result;
            if (emailExist)
            {
                return USER_REGISTERED_EMAIL_MESSAGE;
            }

            var user = _mapper.Map<User>(userDTO);
            user.Rol_id = 2;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            await _unitOfWork.UserRepository!.Insert(user);
            await _unitOfWork.SaveChangesAsync();
            return USER_SUCCESSFUL_ADDED_MESSAGE;
        }

        return USER_EMAIL_INCORRECT_MESSAGE;
    }

    public async Task<bool> UpdateUser(int id, UserForUpdateDto userDTO)
    {
        var userEntity = await _unitOfWork.UserRepository.GetById(id);

        if (userEntity is null)
            return false;

        if (userDTO.First_name is not null)
            userEntity.First_name = userDTO.First_name;

        if (userDTO.Last_name is not null)
            userEntity.Last_name = userDTO.Last_name;

        if (userDTO.Password is not null)
            userEntity.Password = userDTO.Password;

        if (userDTO.Points is not null)
            userEntity.Points = userDTO.Points.Value;

        await _unitOfWork.UserRepository!.Update(userEntity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var deleteUser = await _unitOfWork.UserRepository.GetById(id);
        if (deleteUser is null)
            return false;

        await _unitOfWork.UserRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<(bool Success, string Message)> Exchange(int id, string userIdFromToken)
    {
        var userEntity = await _unitOfWork.UserRepository!.GetById(int.Parse(userIdFromToken));
        var catalogueEntity = await _unitOfWork.CatalogueRepository!.GetById(id);

        if (userEntity is null)
            return (false, USER_NOT_FOUND_MESSAGE);

        if (userEntity.Points < catalogueEntity!.Points)
            return (false, USER_INSUFFICIENT_POINTS_MESSAGE);


        userEntity.Points -= catalogueEntity.Points;


        await _unitOfWork.UserRepository!.Update(userEntity);
        if (await _unitOfWork.SaveChangesAsync() > 0) return (true, USER_SUCCESSFUL_OPERATION_MESSAGE);
        return (false, DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(int totalPages, IEnumerable<User> recordList)> GetUsersPaging(int pageNumber, int pageSize)
    {
        return await _unitOfWork.UserRepository!.GetAllPaging(pageNumber, pageSize);
    }

    private static bool IsEmailValid(string email)
    {
        Regex regex = new("^[_a-z0-9A-Z]+(\\.[_a-z0-9A-Z]+)*@[a-zA-Z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-zA-Z]{2,15})$");
        if (regex.IsMatch(email))
            return true;
        return false;
    }
}