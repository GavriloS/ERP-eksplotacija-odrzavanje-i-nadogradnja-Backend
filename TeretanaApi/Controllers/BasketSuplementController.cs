using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.BasketSuplement;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/basketSuplement")]
    [Produces("application/json")]
    public class BasketSuplementController
    {
        private readonly IBasketSuplementRepository basketSuplementRepository;
        private readonly ISuplementRepository suplementRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public BasketSuplementController(IBasketSuplementRepository basketSuplementRepository, ISuplementRepository suplementRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.basketSuplementRepository = basketSuplementRepository;
            this.suplementRepository = suplementRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet("{basketId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<BasketSuplementDto>>> GetBasketSuplementByBasketId(Guid? basketId = null)
        {
            var basketSuplements = await basketSuplementRepository.GetSuplementsAsync(basketId);
            if (basketSuplements == null || basketSuplements.Count == 0)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(mapper.Map<List<BasketSuplementDto>>(basketSuplements));
        }

        [HttpGet("{basketId}/{suplementId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketSuplementDto>> GetBasketSuplementById(Guid basketId, Guid suplementId)
        {
            var basketSuplement = await basketSuplementRepository.GetBasketSuplementByIdAsync(basketId, suplementId);
            if (basketSuplement == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(mapper.Map<BasketSuplementDto>(basketSuplement));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BasketSuplementDto>> CreateBasketSuplement(BasketSuplementCreationDto newBasketSuplement)
        {
            try
            {
                var basketSuplement = await basketSuplementRepository.GetBasketSuplementByIdAsync(newBasketSuplement.BasketId, newBasketSuplement.SuplementId);
                var suplement = await suplementRepository.GetSuplementByIdAsync(newBasketSuplement.SuplementId);
                if (basketSuplement != null)
                {
                    basketSuplement.Quantity += newBasketSuplement.Quantity;
                    if (suplement.Quantity < basketSuplement.Quantity)
                    {
                        return new BadRequestObjectResult("Nema dovoljno proizvoda na stanju");
                    }
                    await basketSuplementRepository.SaveChangesAsync();
                    return new OkObjectResult(mapper.Map<BasketSuplementDto>(basketSuplement));
                }
                if (suplement.Quantity < newBasketSuplement.Quantity)
                {
                    return new BadRequestObjectResult("Nema dovoljno proizvoda na stanju");
                }
                var basketSuplementnew = await basketSuplementRepository.CreateBasketSuplementAsync(mapper.Map<BasketSuplement>(newBasketSuplement));
                await basketSuplementRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<BasketSuplementDto>(basketSuplementnew));

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
        public async Task<ActionResult<BasketSuplementDto>> UpdateBasketSuplement(BasketSuplementUpdateDto newBasketSuplement)
        {
            var oldBasketSuplement = await basketSuplementRepository.GetBasketSuplementByIdAsync(newBasketSuplement.BasketId, newBasketSuplement.SuplementId);
            if (oldBasketSuplement == null)
            {
                return new NotFoundResult();
            }
            var suplement = await suplementRepository.GetSuplementByIdAsync(newBasketSuplement.SuplementId);
            if (suplement == null)
            {
                return new BadRequestObjectResult("Ne postoji izabrani proizvod");
            }
            try
            {
                oldBasketSuplement.Quantity += newBasketSuplement.Quantity;
                if (oldBasketSuplement.Quantity > suplement.Quantity)
                {
                    return new BadRequestObjectResult("Nema dovoljno proizvoda");
                }
                await basketSuplementRepository.SaveChangesAsync();
                return new OkObjectResult(mapper.Map<BasketSuplementDto>(oldBasketSuplement));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{basketId}/{suplementId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteBasketSuplement(Guid basketId, Guid suplementId)
        {
            var basketSuplement = await basketSuplementRepository.GetBasketSuplementByIdAsync(basketId, suplementId);
            if (basketSuplement == null)
            {
                return new NotFoundResult();
            }
            var suplement = await suplementRepository.GetSuplementByIdAsync(suplementId);
            try
            {
                suplement.Quantity += basketSuplement.Quantity;
                await basketSuplementRepository.DeleteBasketSuplementByIdAsync(basketId, suplementId);
                await basketSuplementRepository.SaveChangesAsync();

                return new OkResult();

            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
