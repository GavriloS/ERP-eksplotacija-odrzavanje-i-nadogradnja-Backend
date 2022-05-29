using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;
using TeretanaApi.Model.Product;
using TeretanaApi.Model.Suplement;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/suplement")]
    [Produces("application/json")]
    public class SuplementController
    {
        private readonly ISuplementRepository suplementRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public SuplementController(ISuplementRepository suplementRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.suplementRepository = suplementRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<ActionResult<SuplementsDto>> GetSuplements(int page,int results,string? name = null)
        {

            var suplements = await suplementRepository.GetSuplementsAsync(page,results,name);

            if(suplements == null|| suplements.Count == 0)
            {
                return new NoContentResult();
            }
       
            var pageCount = Math.Ceiling( (double)(await suplementRepository.GetSuplementCountAsync()) / (double)results);

            var resultSuplements = new SuplementsDto()
            {
                Suplements = mapper.Map<List<ProductDto>>(suplements),
                CurrentPage = page,
                TotalPages = (int)pageCount
            };
            return new OkObjectResult(resultSuplements);
        }
        [HttpGet("{suplementId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<ActionResult<Suplement>> GetSuplementById(Guid suplementId)
        {
            var suplement = await suplementRepository.GetSuplementByIdAsync(suplementId);

            if(suplement == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(suplement);
        }
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Suplement>> CreateSuplement(SuplementCreationDto suplement)
        {
            try
            {
                var newSuplement = await suplementRepository.CreateSuplementAsync(mapper.Map<Suplement>(suplement));

                await suplementRepository.SaveChangesAsync();

                string location = linkGenerator.GetPathByAction("GetSuplementById", "Suplement", new { suplementId = newSuplement.SuplementId });

                return new CreatedResult(location, newSuplement);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                
            }
        }

        [HttpDelete("{suplementId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSuplement(Guid suplementId)
        {
            try
            {
                var suplement = await suplementRepository.GetSuplementByIdAsync(suplementId);

                if (suplement == null) 
                {
                    return new NotFoundResult();
                }

                await suplementRepository.DeleteSuplementByIdAsync(suplementId);
                await suplementRepository.SaveChangesAsync();

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
        public async Task<ActionResult<Suplement>> UpdateSuplement(SuplementUpdateDto suplement)
        {
            try
            {
                var oldSuplement = await suplementRepository.GetSuplementByIdAsync(suplement.Id);

                if(oldSuplement == null)
                {
                    return new NotFoundResult();
                }

                mapper.Map(suplement, oldSuplement);

                await suplementRepository.SaveChangesAsync();

                return new OkObjectResult(oldSuplement);

            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                throw;
            }
        }
    }

}
