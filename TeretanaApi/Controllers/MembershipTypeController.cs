using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.MembershipType;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/membershipType")]
    [Produces("application/json")]
    public class MembershipTypeController
    {
        private readonly IMembershipTypeRepository membershipTypeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public MembershipTypeController(IMembershipTypeRepository membershipTypeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.membershipTypeRepository = membershipTypeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<List<MembershipType>>> GetMembershipTypes()
        {
            var membershipTypes = await membershipTypeRepository.GetMembershipTypesAsync();

            if(membershipTypes == null || membershipTypes.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(membershipTypes);
        }
        [HttpGet("{membershipTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<MembershipType>> GetMembershipTypeById(Guid membershipTypeId)
        {
            var membershipType = await membershipTypeRepository.GetMembershipTypeByIdAsync(membershipTypeId);

            if(membershipType == null) 
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(membershipType);
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MembershipType>> CreateMembershipType(MembershipTypeCreationDto membershipType)
        {
            try
            {
                var m = mapper.Map<MembershipType>(membershipType);
               
                var productService = new ProductService();
                var priceService = new PriceService();
                var productOptions = new ProductCreateOptions
                {
                    Name = m.Name,

                };

                var product = productService.Create(productOptions);
                m.ProductId = product.Id;
                var priceOptions = new PriceCreateOptions
                {
                    UnitAmount = Convert.ToInt64(m.Price) * 100,
                    Currency = "rsd",

                    Product = product.Id
                };

                var price = priceService.Create(priceOptions);
                m.PriceId = price.Id;

                var newMembershipType = await membershipTypeRepository.CreateMembershipTypeAsync(m);


                await membershipTypeRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetMembershipTypeById", "MembershipType", new { membershipTypeId = newMembershipType.MembershipTypeId });
                return new CreatedResult(location,newMembershipType);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{membershipTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMembershipTypeById(Guid membershipTypeId)
        {
            var membershipType = await membershipTypeRepository.GetMembershipTypeByIdAsync(membershipTypeId);

            if(membershipType == null)
            {
                return new NotFoundResult();
            }
            try
            {
                await membershipTypeRepository.DeleteMembershipTypeByIdAsync(membershipTypeId);
                await membershipTypeRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
             
            }
        }
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MembershipType>> UpdateMembershipType(MembershipType membershipType)
        {
            var oldMembershipType = await membershipTypeRepository.GetMembershipTypeByIdAsync(membershipType.MembershipTypeId);

            if (oldMembershipType == null)
            {
                return new NotFoundResult();
            }
            try
            {
                mapper.Map(membershipType, oldMembershipType);
                await membershipTypeRepository.SaveChangesAsync();
                return new OkObjectResult(oldMembershipType);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
