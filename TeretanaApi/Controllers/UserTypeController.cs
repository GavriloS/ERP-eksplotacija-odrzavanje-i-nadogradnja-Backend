using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/userType")]
    [Produces("application/json")]
    public class UserTypeController
    {
        private readonly IUserTypeRepository userTyepRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public UserTypeController(IUserTypeRepository userTyepRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.userTyepRepository = userTyepRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<UserType>>> GetUserTypes()
        {
            var userTypes = await userTyepRepository.GetUserTypesAsync();
            if(userTypes == null|| userTypes.Count == 0)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(userTypes);
        }
        [HttpGet("{userTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserType>> GetUserTypeById(Guid userTypeId)
        {
            var userType = await userTyepRepository.GetUserTypeByIdAsync(userTypeId);
            if(userType == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(userType);
        }
    }
}
