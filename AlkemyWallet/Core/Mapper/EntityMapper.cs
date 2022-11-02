using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Entities;
using AutoMapper;

namespace AlkemyWallet.Core.Mapper
{
    public class EntityMapper
    {


        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Account,AccountDTO>();
                cfg.CreateMap<AccountDTO,Account>();
                cfg.CreateMap<Transaction,TransactionDTO>();
                cfg.CreateMap<TransactionDTO,Transaction>();
                cfg.CreateMap<FixedTermDeposit,FixedTermDepositDTO>();
                cfg.CreateMap<FixedTermDepositDTO,FixedTermDeposit>();
                cfg.CreateMap<Catalogue,CatalogueDTO>();
                cfg.CreateMap<CatalogueDTO,Catalogue>();
                cfg.CreateMap<Login, LoginDTO>();
                cfg.CreateMap<LoginDTO, Login>();
            });

        }
    }
}
