using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Suplement;

namespace TeretanaApi.Profiles
{
    public class SuplementProfile : Profile
    {
        public SuplementProfile()
        {
            CreateMap<SuplementCreationDto, Suplement>();
            CreateMap<Suplement, Suplement>();
            CreateMap<SuplementUpdateDto, Suplement>();
            CreateMap<Suplement, SuplementBasicDto>();
        }
    }
}
