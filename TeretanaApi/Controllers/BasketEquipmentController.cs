using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.BasketEquipment;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/basketEquipment")]
    [Produces("application/json")]
    public class BasketEquipmentController
    {
        private readonly IBasketEquipmentRepository basketEquipmentRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public BasketEquipmentController(IBasketEquipmentRepository basketEquipmentRepository, IMapper mapper, LinkGenerator linkGenerator, IEquipmentRepository equipmentRepository)
        {
            this.basketEquipmentRepository = basketEquipmentRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.equipmentRepository = equipmentRepository;
        }
        [HttpGet("{basketId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<BasketEquipmentDto>>> GetBasketEquipmentByBasketId(Guid? basketId = null)
        {
            var basketEquipments = await basketEquipmentRepository.GetEqupmentsAsync(basketId);
            if(basketEquipments == null || basketEquipments.Count == 0)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(mapper.Map<List<BasketEquipmentDto>>(basketEquipments));
        }

        [HttpGet("{basketId}/{equipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketEquipmentDto>> GetBasketEquipmentById(Guid basketId,Guid equipmentId)
        {
            var basketEquipment = await basketEquipmentRepository.GetBasketEquipmentByIdAsync(basketId, equipmentId);
            if(basketEquipment == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(mapper.Map<BasketEquipmentDto>(basketEquipment));
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketEquipmentDto>> CreateBasketEquipment(BasketEquipmentCreationDto newBasketEquipment)
        {
            try
            {
                var basketEquipment = await basketEquipmentRepository.GetBasketEquipmentByIdAsync(newBasketEquipment.BasketId, newBasketEquipment.EquipmentId);
                var equipment = await equipmentRepository.GetEquipmentByIdAsync(newBasketEquipment.EquipmentId);
                if (basketEquipment != null)
                {
                    basketEquipment.Quantity += newBasketEquipment.Quantity;
                    if (equipment.Quantity < basketEquipment.Quantity)
                    {
                        return new BadRequestObjectResult("Nema dovoljno proizvoda na stanju");
                    }
                    await basketEquipmentRepository.SaveChangesAsync();
                    return new OkObjectResult(mapper.Map<BasketEquipmentDto>(basketEquipment));
                }
                if (equipment.Quantity < newBasketEquipment.Quantity)
                {
                    return new BadRequestObjectResult("Nema dovoljno proizvoda na stanju");
                }
                var basketEquipmentnew = await basketEquipmentRepository.CreateBasketEquipmentAsync(mapper.Map<BasketEquipment>(newBasketEquipment));
                await basketEquipmentRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<BasketEquipmentDto>(basketEquipmentnew));
               
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }
        }
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketEquipmentDto>> UpdateBasketEquipment(BasketEquipmentUpdateDto newBasketEquipment)
        {
            var oldBasketEquipment = await basketEquipmentRepository.GetBasketEquipmentByIdAsync(newBasketEquipment.BasketId, newBasketEquipment.EquipmentId);
            if (oldBasketEquipment == null)
            {
                return new NotFoundResult();
            }
            var equipment = await equipmentRepository.GetEquipmentByIdAsync(newBasketEquipment.EquipmentId);
            if(equipment == null)
            {
                return new BadRequestObjectResult("Ne postoji izabrani proizvod");
            }
            try
            {
                oldBasketEquipment.Quantity += newBasketEquipment.Quantity;
                if(oldBasketEquipment.Quantity> equipment.Quantity)
                {
                    return new BadRequestObjectResult("Nema dovoljno proizvoda");
                }
                await basketEquipmentRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<BasketEquipmentDto>(oldBasketEquipment));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{basketId}/{equipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteBasketEquipment(Guid basketId,Guid equipmentId)
        {
            var basketEquipment = await basketEquipmentRepository.GetBasketEquipmentByIdAsync(basketId, equipmentId);
            if(basketEquipment == null)
            {
                return new NotFoundResult();
            }
            var equipment = await equipmentRepository.GetEquipmentByIdAsync(equipmentId);
            try
            {
                equipment.Quantity += basketEquipment.Quantity;
                await basketEquipmentRepository.DeleteBasketEquipmentById(basketId, equipmentId);
                await basketEquipmentRepository.SaveChangesAsync();
          
                return new OkResult();
              
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
