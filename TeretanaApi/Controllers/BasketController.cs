using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.Basket;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/basket")]
    [Produces("application/json")]
    public class BasketController
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly ISuplementRepository suplementRepository;
        private readonly IEquipmentRepository equipmentRepository;

        public BasketController(IBasketRepository basketRepository, IMapper mapper, LinkGenerator linkGenerator,IEquipmentRepository equipmentRepository,ISuplementRepository suplementRepository)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.suplementRepository = suplementRepository;
            this.equipmentRepository = equipmentRepository;
        }
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<BasketDto>>> GetBaskets()
        {
            var baskets = await basketRepository.GetBasketsAsync();

            if(baskets == null || baskets.Count == 0)
            {
                return new NoContentResult();
            }
          

            return new OkObjectResult(mapper.Map<List<BasketDto>>(baskets));
        }

        [HttpGet("{basketId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketDto>> GetBasketById(Guid basketId)
        {
            var basket = await basketRepository.GetBasketByIdAsync(basketId);

            if(basket == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(mapper.Map<BasketDto>(basket));
        }


        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<BasketDto>>> GetBasketByUser(Guid userId,bool open = false)
        {

            Basket basket = null;
            List<Basket> baskets = null;
            if (open)
            {
                basket = await this.basketRepository.GetOpenBasketByUser(userId);
                if (basket == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(mapper.Map<BasketDto>(basket));
            }
            else
            {
                baskets = await this.basketRepository.GetBasketsByUser(userId);
                if (baskets == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(mapper.Map<List<BasketDto>>(baskets));
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketDto>> CreateBasket(BasketCreationDto basket)
        {
            var newBasket = mapper.Map<Basket>(basket);
            if(basket.EquipmentIds.Keys.Count > 0)
            {
                newBasket.Equipments = new List<BasketEquipment>();
            }
            if(basket.SuplementIds.Keys.Count > 0)
            {
                newBasket.Suplements = new List<BasketSuplement>();
            }
            foreach(var equipmentId in basket.EquipmentIds.Keys)
            {
                var equipment = await equipmentRepository.GetEquipmentByIdAsync(equipmentId);
                if(equipment.Quantity < basket.EquipmentIds[equipmentId])
                {

                    return new BadRequestObjectResult("Nema toliko uređaja na stanju");
                }
                newBasket.Equipments.Add(new BasketEquipment { BasketId = newBasket.BasketId, EquipmentId = equipmentId,Quantity = basket.EquipmentIds[equipmentId] });
            }
            foreach(var suplementId in basket.SuplementIds.Keys)
            {
                var suplement = await suplementRepository.GetSuplementByIdAsync(suplementId);
                if(suplement.Quantity < basket.SuplementIds[suplementId])
                {

                    return new BadRequestObjectResult("Nema toliko suplemenata na stanju");
                }
                newBasket.Suplements.Add(new BasketSuplement { BasketId = newBasket.BasketId, SuplementId = suplementId,Quantity = basket.SuplementIds[suplementId] });
            }
            try
            {
                await basketRepository.CreateBasketAsync(newBasket);
                await basketRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetBasketById", "Basket", new { basketId = newBasket.BasketId });

                return new CreatedResult(location, mapper.Map<BasketDto>(newBasket));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{basketId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> DeleteBasketById(Guid basketId)
        {
            var basket = await basketRepository.GetBasketByIdAsync(basketId);
            if (basket == null)
            {
                return new NotFoundResult();
            }
            try
            {
                await basketRepository.DeleteBasketByIdAsync(basketId);
                await basketRepository.SaveChangesAsync();
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
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketDto>> UpdateBasket(BasketUpdateDto newBasket)
        {
            var oldBasket = await basketRepository.GetBasketByIdAsync(newBasket.BasketId);
            if(oldBasket == null)
            {
                return new NotFoundResult();
            }
            try
            {
                mapper.Map(newBasket, oldBasket);
                await basketRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<BasketDto>(oldBasket));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

     
    }
}
