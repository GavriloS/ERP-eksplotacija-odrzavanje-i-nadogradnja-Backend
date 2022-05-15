using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.GroupTrainingType;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/groupTrainingType")]
    [Produces("application/json")]
    public class GroupTrainingTypeController
    {

        private readonly IGroupTrainingTypeRepository groupTrainingRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public GroupTrainingTypeController(IGroupTrainingTypeRepository groupTrainingRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.groupTrainingRepository = groupTrainingRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }


        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<List<GroupTrainingType>>> GetGroupTrainingTypes()
        {
            var groupTrainingTypes = await groupTrainingRepository.GetGroupTrainingTypesAsync();

            if (groupTrainingTypes == null || groupTrainingTypes.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(groupTrainingTypes);
        }

        [HttpGet("{groupTrainingTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<GroupTrainingType>> GetGroupTrainingTypeById(Guid groupTrainingTypeId)
        {
            var groupTrainingType = await groupTrainingRepository.GetGroupTrainingTypeByIdAsync(groupTrainingTypeId);

            if (groupTrainingType == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(groupTrainingType);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GroupTrainingType>> CreateGroupTrainingType(GroupTrainingTypeCreationDto groupTrainingType)
        {
            try
            {
                var newGroupTrainingType = await groupTrainingRepository.CreateGroupTrainingTypeAsync(mapper.Map<GroupTrainingType>(groupTrainingType));

                await groupTrainingRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetGroupTrainingTypeById", "GroupTrainingType", new { groupTrainingTypeId = newGroupTrainingType.GroupTrainingTypeId });

                return new CreatedResult(location, newGroupTrainingType);


            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{groupTrainingTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteGroupTrainingType(Guid groupTrainingTypeId)
        {
            try
            {
                var groupTraining = await groupTrainingRepository.GetGroupTrainingTypeByIdAsync(groupTrainingTypeId);

                if(groupTraining == null)
                {
                    return new NotFoundResult();
                }

                await groupTrainingRepository.DeleteGroupTrainingTypeAsync(groupTrainingTypeId);
                await groupTrainingRepository.SaveChangesAsync();

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
        public async Task<ActionResult<GroupTrainingType>> UpdateGroupTrainingType(GroupTrainingType groupTrainingType)
        {
            try
            {
                var oldGroupTrainingType = await groupTrainingRepository.GetGroupTrainingTypeByIdAsync(groupTrainingType.GroupTrainingTypeId);

                if(oldGroupTrainingType == null)
                {
                    return new NotFoundResult();
                }

                mapper.Map(groupTrainingType, oldGroupTrainingType);

                await groupTrainingRepository.SaveChangesAsync();
                return new OkObjectResult(oldGroupTrainingType);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
