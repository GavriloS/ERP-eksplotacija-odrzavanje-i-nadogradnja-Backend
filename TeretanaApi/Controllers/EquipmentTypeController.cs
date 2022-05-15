using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.EquipmentType;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/equipmentType")]
    [Produces("application/json")]
    public class EquipmentTypeController
    {
        private readonly IEquipmentTypeRepository equipmentTypeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public EquipmentTypeController(IEquipmentTypeRepository equipmentTypeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.equipmentTypeRepository = equipmentTypeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<List<EquipmentType>>> GetEquipmentTypes()
        {
            var equipmentTypes = await equipmentTypeRepository.GetEquipmentTypesAsync();

            if (equipmentTypes == null || equipmentTypes.Count == 0)
            {
                return new NoContentResult();

            }

            return new OkObjectResult(equipmentTypes);
        }

        [HttpGet("{equipmentTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<EquipmentType>> GetEquipmentTypeById(Guid equipmentTypeId)
        {
            var equipmentType = await equipmentTypeRepository.GetEquipmentTypeByIdAsync(equipmentTypeId);

            if (equipmentType == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(equipmentType);
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EquipmentType>> CreateEquipmentType(EquipmentTypeCreationDto equipmentType)
        {
            try
            {
                var newEquipmentType = await equipmentTypeRepository.CreateEquipmentTypeAsync(mapper.Map<EquipmentType>(equipmentType));
                await equipmentTypeRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetEquipmentTypeById", "EquipmentType", new { equipmentTypeId = newEquipmentType.EquipmentTypeId });

                return new CreatedResult(location, newEquipmentType);
            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{equipmentTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEquipmentType(Guid equipmentTypeId)
        {
            try
            {
                var equipmentType = await equipmentTypeRepository.GetEquipmentTypeByIdAsync(equipmentTypeId);

                if(equipmentType == null)
                {
                    return new NotFoundResult();
                }

                await equipmentTypeRepository.DeleteEquipmentTypeByIdAsync(equipmentTypeId);
                await equipmentTypeRepository.SaveChangesAsync();

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
        public async Task<ActionResult<EquipmentType>> UpdateEqupmentType(EquipmentType newEqupmentType)
        {
            try
            {
                var oldEquipmentType = await equipmentTypeRepository.GetEquipmentTypeByIdAsync(newEqupmentType.EquipmentTypeId);

                if(oldEquipmentType == null)
                {
                    return new NotFoundResult();
                }

                mapper.Map(newEqupmentType, oldEquipmentType);
                await equipmentTypeRepository.SaveChangesAsync();

                return new OkObjectResult(oldEquipmentType);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
