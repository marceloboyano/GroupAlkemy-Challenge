using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Entities;
using AutoMapper;

namespace AlkemyWallet.Core.Mapper

{
    public class AutomapperProfile : Profile
    {

        public AutomapperProfile()
        {

            CreateMap<Catalogue, CatalogueDTO>().ReverseMap();
            CreateMap<Catalogue, CatalogueForCreationDTO>().ReverseMap();
         

        }
    }
}

