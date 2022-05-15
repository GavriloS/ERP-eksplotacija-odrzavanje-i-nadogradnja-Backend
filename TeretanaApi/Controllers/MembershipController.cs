using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.Membership;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/membership")]
    [Produces("application/json")]
    public class MembershipController
    {
        private readonly IMembershipRepository membershipRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public MembershipController(IMembershipRepository membershipRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.membershipRepository = membershipRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<MembershipDto>>> GetMemberships(Guid? userId = null)
        {
            var memberships = await membershipRepository.GetMembershipsAsync(userId);

            if(memberships == null || memberships.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(mapper.Map<List<MembershipDto>>(memberships));
        }
        [HttpGet("{membershipId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<MembershipDto>> GetMembershipById(Guid membershipId)
        {
            var membership = await membershipRepository.GetMembershipByIdAsync(membershipId);

            if(membership == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(mapper.Map<MembershipDto>(membership));
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<MembershipDto>> CreateMembership(MembershipCreationDto membership)
        {
            try
            {
                var newMembership = await membershipRepository.CreateMembershipAsync(mapper.Map<Membership>(membership));

                await membershipRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetMembershipById", "Membership", new { membershipId = newMembership.MembershipId });
                return new CreatedResult(location, mapper.Map<MembershipDto>(newMembership));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                
            }
        }
        [HttpDelete("{membershipId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> DeleteMembership(Guid membershipId)
        {
            var membership = await membershipRepository.GetMembershipByIdAsync(membershipId);

            if(membership == null)
            {
                return new NotFoundResult();
            }

            try
            {
                await membershipRepository.DeleteMembershipByIdAsync(membershipId);
                await membershipRepository.SaveChangesAsync();
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
        [Authorize(Roles ="Admin,User")]
        public async Task<ActionResult<MembershipDto>> UpdateMembership(MembershipUpdateDto membership)
        {
            var oldMembership = await membershipRepository.GetMembershipByIdAsync(membership.MembershipId);
            if(oldMembership == null)
            {
                return new NotFoundResult();

            }
            try
            {
                mapper.Map(membership, oldMembership);
                await membershipRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<MembershipDto>(oldMembership));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
         
            }
        }



    }
}
