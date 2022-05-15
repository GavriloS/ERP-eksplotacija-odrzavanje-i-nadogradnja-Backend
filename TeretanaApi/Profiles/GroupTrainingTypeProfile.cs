using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.GroupTrainingType;

namespace TeretanaApi.Profiles
{
    public class GroupTrainingTypeProfile : Profile
    {
        public GroupTrainingTypeProfile()
        {
            CreateMap<GroupTrainingTypeCreationDto, GroupTrainingType>();
            CreateMap<GroupTrainingType, GroupTrainingType>();
        }
    }
}
