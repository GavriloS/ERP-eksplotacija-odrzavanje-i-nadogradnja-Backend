using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.MembershipType;

namespace TeretanaApi.Profiles
{
    public class MembershipTypeProfile : Profile
    {
        public MembershipTypeProfile()
        {
            CreateMap<MembershipTypeCreationDto,MembershipType>();
            CreateMap<MembershipType, MembershipType>();
        }
    }
}
