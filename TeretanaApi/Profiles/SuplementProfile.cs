using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Product;
using TeretanaApi.Model.Suplement;

namespace TeretanaApi.Profiles
{
    public class SuplementProfile : Profile
    {
        public SuplementProfile()
        {
            CreateMap<SuplementCreationDto, Suplement>()
                .ForMember(
                dest => dest.SuplementTypeId,
                opt => opt.MapFrom(src => src.TypeId));
            CreateMap<Suplement, Suplement>();
            CreateMap<SuplementUpdateDto, Suplement>()
                .ForMember(
                dest => dest.SuplementId,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(
                dest => dest.SuplementTypeId,
                opt => opt.MapFrom(src => src.TypeId));

            CreateMap<Suplement, SuplementBasicDto>();

            CreateMap<Suplement, ProductDto>()
              .ForMember(
              dest => dest.Id,
              opt => opt.MapFrom(src => src.SuplementId))
              .ForMember(
              dest => dest.Name,
              opt => opt.MapFrom(src => src.Name))
              .ForMember(
              dest => dest.Price,
              opt => opt.MapFrom(src => src.Price))
              .ForMember(
              dest => dest.Type,
              opt => opt.MapFrom(src => "s"))
              .ForMember(
                dest => dest.PriceId,
                opt => opt.MapFrom(src => src.PriceId));
        }
    }
}
