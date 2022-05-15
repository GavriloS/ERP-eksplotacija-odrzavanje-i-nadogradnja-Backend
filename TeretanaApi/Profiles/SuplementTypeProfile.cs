using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.SuplementType;

namespace TeretanaApi.Profiles
{
    public class SuplementTypeProfile : Profile
    {
        public SuplementTypeProfile()
        {
            CreateMap<SuplementTypeCreationDto, SuplementType>();
            CreateMap<SuplementType, SuplementType>();
        }
    }
}
