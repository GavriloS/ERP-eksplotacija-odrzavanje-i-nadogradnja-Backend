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
                opt => opt.MapFrom(src => src.PriceId))
                .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity));

            CreateMap<EquipmentCreationDto, Equipment>();

            CreateMap<EquipmentUpdateDto, Equipment>();
        }
    }
}
