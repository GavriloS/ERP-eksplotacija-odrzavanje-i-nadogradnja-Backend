using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Equipment;

namespace TeretanaApi.Profiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentBasicDto>();
        }
    }
}
