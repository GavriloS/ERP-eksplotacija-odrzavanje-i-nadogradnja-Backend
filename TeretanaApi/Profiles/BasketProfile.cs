using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Basket;

namespace TeretanaApi.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket,BasketDto>()
                .ForMember(
                dest => dest.Equipments,
                opt => opt.MapFrom(src => src.Equipments))
                .ForMember(
                dest => dest.Suplements,
                opt => opt.MapFrom(src => src.Suplements))
                .ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => src.User));

            CreateMap<Basket, Basket>();
            CreateMap<BasketCreationDto, Basket>()
                .ForMember(
                dest => dest.Equipments,
                opt => opt.Ignore())
                .ForMember(
                dest => dest.Suplements,
                opt => opt.Ignore());
            //Vidi ovo
            
            CreateMap<BasketUpdateDto, Basket>()
                .ForMember(
                dest => dest.User,
                opt => opt.UseDestinationValue());
            
        }
    }
}
