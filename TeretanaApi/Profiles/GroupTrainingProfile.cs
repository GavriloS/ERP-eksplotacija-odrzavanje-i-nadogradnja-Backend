using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.GroupTraining;

namespace TeretanaApi.Profiles
{
    public class GroupTrainingProfile : Profile
    {
        public GroupTrainingProfile()
        {
            CreateMap<GroupTraining, GroupTrainingDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.GroupTrainingType.Name))
                 .ForMember(
                dest => dest.Duration,
                opt => opt.MapFrom(src => src.GroupTrainingType.Duration))
                  .ForMember(
                dest => dest.TrainerName,
                opt => opt.MapFrom(src => src.Trainer.FirstName +' '+src.Trainer.LastName))
                  .ForMember(
                dest => dest.Users,
                opt => opt.MapFrom(src => src.Users.Select(u => u.UserId).ToList()));

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
