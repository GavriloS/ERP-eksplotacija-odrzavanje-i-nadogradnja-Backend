using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.SuplementType;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/suplementType")]
    [Produces("application/json")]
    public class SuplementTypeController
    {
        private readonly ISuplementTypeRepository suplementTypeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public SuplementTypeController(ISuplementTypeRepository suplementTypeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.suplementTypeRepository = suplementTypeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<List<SuplementType>>> GetSuplementTypes()
        {
            var suplementTypes = await suplementTypeRepository.GetSuplementTypesAsync();

            if(suplementTypes == null || suplementTypes.Count == 0)
            {
                return  new NoContentResult();
            }

            return new OkObjectResult(suplementTypes);
        }

        [HttpGet("{suplementTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<SuplementType>> GetSuplementTypeId(Guid suplementTypeId)
        {
            var suplementType = await suplementTypeRepository.GetSuplementTypesByIdAsync(suplementTypeId);

            if(suplementType == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(suplementType);
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SuplementType>> CreateSuplementType(SuplementTypeCreationDto suplementType)
        {
            try
            {
                var newSuplementType = await suplementTypeRepository.CreateSuplementTypeAsync(mapper.Map<SuplementType>(suplementType));
                await suplementTypeRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetSuplementTypeId", "SuplementType", new { suplementTypeId = newSuplementType.SuplementTypeId });

                return new CreatedResult(location, newSuplementType);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
               
            }
        }
        [HttpDelete("{suplementTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSuplementType(Guid suplementTypeId)
        {
            try
            {
                var suplementType = await suplementTypeRepository.GetSuplementTypesByIdAsync(suplementTypeId);

                if(suplementType == null)
                {
                    return new NotFoundResult();
                }

                await suplementTypeRepository.DeleteSuplementTypesByIdAsync(suplementTypeId);
                await suplementTypeRepository.SaveChangesAsync();

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
        public async Task<ActionResult<SuplementType>> UpdateSuplementType(SuplementType suplementType)
        {
            try
            {
                var oldSuplementType = await suplementTypeRepository.GetSuplementTypesByIdAsync(suplementType.SuplementTypeId);

                if(oldSuplementType == null)
                {
                    return new NotFoundResult();
                }

                mapper.Map(suplementType, oldSuplementType);

                await suplementTypeRepository.SaveChangesAsync();

                return new OkObjectResult(oldSuplementType);
            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
