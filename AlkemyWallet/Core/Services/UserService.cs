using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using static AlkemyWallet.Core.Helper.Constants;
using static AlkemyWallet.Core.Helper.ApiHelper;

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

    public async Task<IEnumerable<User>> GetAllUser() => await _unitOfWork.UserRepository.GetAll();



    public async Task<User?> GetById(int id) => await _unitOfWork.UserRepository.GetById(id);



    public async Task<(bool Success, string Message)> AddUser(UserForCreatoionDto userDTO)
    {
        var isValidEmailValid = IsEmailValid(userDTO.Email);

        if (!isValidEmailValid)
            return (Success: false, Message: USER_EMAIL_INCORRECT_MESSAGE);

        var emailExist = _unitOfWork.UserDetailsRepository.GetUserByEmail(userDTO.Email).Result;

        if (emailExist)
            return (Success: false, Message: USER_REGISTERED_EMAIL_MESSAGE);

        var user = _mapper.Map<User>(userDTO);
        user.Rol_id = 2;
        user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

        await _unitOfWork.UserRepository.Insert(user);
        return (Success: await _unitOfWork.SaveChangesAsync() > 0, Message: USER_SUCCESSFUL_ADDED_MESSAGE);        

    }

    public async Task<(bool Success, string Message)> UpdateUser(int id, UserForUpdateDto userDTO)
    {
        var userEntity = await _unitOfWork.UserRepository.GetById(id);

        if (userEntity is null)
            return (Success: false, Message: USER_NOT_FOUND_MESSAGE);

        if (userDTO.First_name is not null)
            userEntity.First_name = userDTO.First_name;

        if (userDTO.Last_name is not null)
            userEntity.Last_name = userDTO.Last_name;

        if (userDTO.Password is not null)
            userEntity.Password = userDTO.Password;

        if (userDTO.Points is not null)
            userEntity.Points = userDTO.Points.Value;

        if (userDTO.Email is not null)
        {
            var isValidEmailValid = IsEmailValid(userDTO.Email);

            if (!isValidEmailValid)
                return (Success: false, Message: USER_EMAIL_INCORRECT_MESSAGE);

            var emailExist = _unitOfWork.UserDetailsRepository.GetUserByEmail(userDTO.Email).Result;

            if (emailExist)
                return (Success: false, Message: USER_REGISTERED_EMAIL_MESSAGE);
            userEntity.Email = userDTO.Email;
        }
        await _unitOfWork.UserRepository!.Update(userEntity);
        return (Success: await _unitOfWork.SaveChangesAsync() > 0, Message: USER_SUCCESSFUL_MODIFIED_MESSAGE);
    }

    public async Task<bool> DeleteUser(int id)
    {
        await _unitOfWork.UserRepository.Delete(id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<(bool Success, string Message)> Exchange(int id, string userIdFromToken)
    {
        var userEntity = await _unitOfWork.UserRepository!.GetById(int.Parse(userIdFromToken));
        var catalogueEntity = await _unitOfWork.CatalogueRepository!.GetById(id);

        if (userEntity is null)
            return (Success: false, Message: USER_NOT_FOUND_MESSAGE);

        if (userEntity.Points < catalogueEntity!.Points)
            return (Success:false, Message:USER_INSUFFICIENT_POINTS_MESSAGE);


        userEntity.Points -= catalogueEntity.Points;


        await _unitOfWork.UserRepository!.Update(userEntity);

        if (await _unitOfWork.SaveChangesAsync() > 0) 
            return (Success: true, Message: USER_SUCCESSFUL_OPERATION_MESSAGE);

        return (Success: false, Message: DB_NOT_EXPECTED_RESULT_MESSAGE);
    }

    public async Task<(int totalPages, IEnumerable<User> recordList)> GetUsersPaging(int pageNumber, int pageSize)
    {
        return await _unitOfWork.UserRepository!.GetAllPaging(pageNumber, pageSize);
    }


}