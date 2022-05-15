using AutoMapper;
using TeretanaApi.Entities;
using TeretanaApi.Model.Address;

namespace TeretanaApi.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreationDto,Address>();

            CreateMap<Address,Address>();
        }
    }
}
