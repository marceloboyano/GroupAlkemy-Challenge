using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AutoMapper;

namespace AlkemyWallet.Core.Mapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
      
        CreateMap<Catalogue, CatalogueForCreationDTO>().ReverseMap();
        CreateMap<Catalogue, CatalogueForShowDTO>().ReverseMap();
        CreateMap<Account, AccountForShowDTO>().ReverseMap();
        CreateMap<Account, AccountForCreationDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserByIdDTO>().ReverseMap();
        CreateMap<User, UserForCreatoionDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<Role, RolesDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
        CreateMap<Transaction, TransactionDTO>().ReverseMap();
        CreateMap<FixedTermDeposit, FixedTermDepositDTO>().ReverseMap();
        CreateMap<FixedTermDeposit, FixedTermDepositForShowDTO>().ReverseMap();
        CreateMap<FixedTermDeposit, DepositForShowDTO>().ReverseMap();
        CreateMap<FixedTermDeposit, DepositForUpdateDTO>().ReverseMap();
        CreateMap<FixedTermDeposit, DepositForCreationDTO>().ReverseMap();
    }
}