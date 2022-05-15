using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.BasketEquipment;

namespace TeretanaApi.Profiles
{
    public class BasketEquipmentProfile : Profile
    {
        public BasketEquipmentProfile()
        {
            CreateMap<BasketEquipment, BasketEquipmentDto>()
                .ForMember(
                dest => dest.Equipment,
                opt => opt.MapFrom(src => src.Equipment));
            CreateMap<BasketEquipmentCreationDto, BasketEquipment>();
            CreateMap<BasketEquipmentUpdateDto, BasketEquipment>();
        }
    }
}
