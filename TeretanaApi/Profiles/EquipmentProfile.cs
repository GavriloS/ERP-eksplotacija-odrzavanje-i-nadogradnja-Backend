using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Equipment;
using TeretanaApi.Model.Product;

namespace TeretanaApi.Profiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentBasicDto>();
            CreateMap<Equipment, ProductDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.EquipmentId))
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
                .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => "e"))
                .ForMember(
                dest => dest.PriceId,
                opt => opt.MapFrom(src => src.PriceId));

            CreateMap<EquipmentCreationDto, Equipment>()
                .ForMember(  
                dest => dest.EquipmentTypeId,
                opt => opt.MapFrom(src => src.TypeId));

            CreateMap<EquipmentUpdateDto, Equipment>()
                .ForMember(
                dest => dest.EquipmentTypeId,
                opt => opt.MapFrom(src => src.TypeId))
                .ForMember(
                dest => dest.EquipmentId,
                opt => opt.MapFrom(src => src.Id));
        }
    }
}
