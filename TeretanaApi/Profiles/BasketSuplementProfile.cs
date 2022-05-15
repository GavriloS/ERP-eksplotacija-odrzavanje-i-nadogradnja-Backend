using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.BasketSuplement;

namespace TeretanaApi.Profiles
{
    public class BasketSuplementProfile : Profile
    {
        public BasketSuplementProfile()
        {
            CreateMap<BasketSuplement, BasketSuplementDto>()
                .ForMember(
                dest => dest.Suplement,
                opt => opt.MapFrom(src => src.Suplement));

            CreateMap<BasketSuplementCreationDto, BasketSuplement>();
            CreateMap<BasketSuplementUpdateDto, BasketSuplement>();
        }
    }
}
