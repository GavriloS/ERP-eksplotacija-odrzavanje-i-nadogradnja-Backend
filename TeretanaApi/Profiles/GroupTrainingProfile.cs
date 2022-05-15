using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.GroupTraining;

namespace TeretanaApi.Profiles
{
    public class GroupTrainingProfile : Profile
    {
        public GroupTrainingProfile()
        {
            CreateMap<GroupTraining, GroupTrainingDto>();
            CreateMap<GroupTraining, GroupTraining>();
            CreateMap<GroupTrainingCreateDto, GroupTraining>();
            //Probaj opt.UseDestinationValue
            CreateMap<GroupTrainingUpdateDto, GroupTraining>()
                .ForMember(
                dest => dest.Users,
                opt => opt.Ignore());
        }
    }
}
