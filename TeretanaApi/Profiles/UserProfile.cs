using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.User;

namespace TeretanaApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserBasicDto>()
                  .ForMember(
                dest => dest.UserType,
                opt => opt.MapFrom(src => src.UserType));
            CreateMap<User, User>();
            CreateMap<UserCreationDto,User>()
                .ForMember(
                dest => dest.Password,
                opt => opt.Ignore());
            CreateMap<UpdateUserDto,User>();
            CreateMap<User,UserDto>()
                .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address))
                .ForMember(
                dest => dest.UserType,
                opt => opt.MapFrom(src => src.UserType));
        }
    }
}
