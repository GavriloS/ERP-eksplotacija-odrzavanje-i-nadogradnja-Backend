using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.Equipment;
using TeretanaApi.Model.Product;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/equipment")]
    [Produces("application/json")]
    public class EquipmentController
    {
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public EquipmentController(IEquipmentRepository equipmentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.equipmentRepository = equipmentRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<EquipmentsDto>> GetEquipments(int page,int results, string orderBy, string? name = null,Guid? typeId = null)
        {
            var equipments = await equipmentRepository.GetEquipmentsAsync(page,results,name,orderBy,typeId);

            if(equipments == null || equipments.Count == 0)
            {
                return new NoContentResult();
            }

            var totalPages = Math.Ceiling((float)(await equipmentRepository.GetEquipmentCountAsync()) / (float)results);

            var equipmentsDto = new EquipmentsDto()
            {
                Equipments = mapper.Map<List<ProductDto>>(equipments),
                CurrentPage = page,
                TotalPages = (int)totalPages
            };
            return new OkObjectResult(equipmentsDto);
        }

        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<Equipment>> GetEquipments()
        {
            var equipments = await equipmentRepository.GetEquipmentsAsync();

            if (equipments == null || equipments.Count == 0)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(equipments);
        }

        [HttpGet("{equipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public  async Task<ActionResult<Equipment>> GetEqupmentById(Guid equipmentId)
        {
            var equipment = await equipmentRepository.GetEquipmentByIdAsync(equipmentId);

            if(equipment == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(equipment);
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Equipment>> CreateEquipment(EquipmentCreationDto equipment)
        {
            try
            {
                var e = mapper.Map<Equipment>(equipment);
   

                var productService = new ProductService();
                var priceService = new PriceService();
                var productOptions = new ProductCreateOptions
                {
                    Name = e.Name,

                };

                var product = productService.Create(productOptions);
                e.ProductId = product.Id;
                var priceOptions = new PriceCreateOptions
                {
                    UnitAmount = Convert.ToInt64(e.Price) * 100,
                    Currency = "rsd",

                    Product = product.Id
                };

                var price = priceService.Create(priceOptions);
                e.PriceId = price.Id;

                var newEquipment = await equipmentRepository.CreateEquipmentAsync(e);
                await equipmentRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetEqupmentById", "Equipment", new { equipmentId = newEquipment.EquipmentId });

                return new CreatedResult(location, newEquipment);
            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{equipmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteEquipment(Guid equipmentId)
        {
            var equipment = await equipmentRepository.GetEquipmentByIdAsync(equipmentId);

            if (equipment == null)
            {
                return new NotFoundResult();
            }

            try
            {
                await equipmentRepository.DeleteEquipmentById(equipmentId);
                await equipmentRepository.SaveChangesAsync();

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
        public async Task<ActionResult<Equipment>> UpdateEquipment(EquipmentUpdateDto equipment) 
        {
            var oldEquipment = await equipmentRepository.GetEquipmentByIdAsync(equipment.EquipmentId);

            if(oldEquipment == null)
            {
                return new NotFoundResult();
            }

            try
            {
                mapper.Map(equipment, oldEquipment);
                await equipmentRepository.SaveChangesAsync();
                return new OkObjectResult(oldEquipment);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
