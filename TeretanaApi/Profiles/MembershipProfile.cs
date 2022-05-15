using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Membership;

namespace TeretanaApi.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<Membership, MembershipDto>()
                .ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => src.User));

            CreateMap<MembershipCreationDto, Membership>();
            CreateMap<MembershipUpdateDto, Membership>();
            CreateMap<Membership, Membership>();
        }
    }
}
