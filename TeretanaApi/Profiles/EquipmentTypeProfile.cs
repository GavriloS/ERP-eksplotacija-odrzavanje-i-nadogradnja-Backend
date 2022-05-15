using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.EquipmentType;

namespace TeretanaApi.Profiles
{
    public class EquipmentTypeProfile : Profile
    {
        public EquipmentTypeProfile()
        {
            CreateMap<EquipmentTypeCreationDto,EquipmentType>();
            CreateMap<EquipmentType, EquipmentType>();
        }
    }
}
