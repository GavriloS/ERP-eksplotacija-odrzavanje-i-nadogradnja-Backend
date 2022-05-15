using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.Address;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/address")]
    [Produces("application/json")]
    public class AddressController
    {
        private readonly IAddressRepository addressRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public AddressController(IAddressRepository addressRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles ="Admin,User,Trainer")]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            var addresses = await addressRepository.GetAddressesAsync();

            if(addresses == null|| addresses.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(addresses);
        }

        [HttpGet("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User,Trainer")]
        public async Task<ActionResult<Address>> GetAddressById(Guid addressId)
        {
            var address = await addressRepository.GetAddressByIdAsync(addressId);

            if(address == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(address);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<ActionResult<Address>> CreateAddress(AddressCreationDto address)
        {
            try
            {
                Address newAddress = await addressRepository.CreateAddressAsync(mapper.Map<Address>(address));
                await addressRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetAddressById", "Address", new { addressId = newAddress.AddressId });
           
                return new CreatedResult(location, newAddress);
            }
            catch(Exception )
            {
                
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteAddress(Guid addressId)
        {
            try
            {
                var address = await addressRepository.GetAddressByIdAsync(addressId);

                if(address == null)
                {
                    return new NotFoundResult();
                }

                await addressRepository.DeleteAddressByIdAsync(addressId);
                await addressRepository.SaveChangesAsync();

                return new OkResult();
            }catch(Exception )
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User,Trainer")]
        public async Task<ActionResult<Address>> UpdateAddress(Address address)
        {
            try
            {
                var oldAddress = await addressRepository.GetAddressByIdAsync(address.AddressId);

                if(oldAddress == null)
                {
                    return new NotFoundResult();
                }

                mapper.Map(address, oldAddress);

                await addressRepository.SaveChangesAsync();

                return new OkObjectResult(oldAddress);
            }catch(Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
