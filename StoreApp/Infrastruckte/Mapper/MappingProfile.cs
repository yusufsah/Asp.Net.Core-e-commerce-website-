using AutoMapper;
using Entites.Dtos;
using Entites.Models;

namespace StoreApp.Infrastruckte.Mapper
{
    public class MappingProfile : Profile // burası mapper işlemi için oluşturuldu
    {
        public MappingProfile()
        {
            CreateMap<ProductDtosForinsertion,Product>();
            CreateMap<ProductDtosForUpdate, Product>().ReverseMap();
        }

    }
}
