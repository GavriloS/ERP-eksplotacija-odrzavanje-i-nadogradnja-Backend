
using Microsoft.AspNetCore.Mvc;

using Stripe;
using Stripe.Checkout;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Model.Stripe;
using System.IO;

namespace TeretanaApi.Controllers
{
    [ApiController]
    [Route("api/stripe")]
    [Produces("application/json")]
    public class CheckoutApiController : ControllerBase
    {
        private IEquipmentRepository equipmentRepositry;
        private ISuplementRepository suplementRepository;
        private IMembershipTypeRepository membershipTypeRepository;
        private readonly IConfiguration _config;

        public CheckoutApiController(IEquipmentRepository equipmentRepositry, ISuplementRepository suplementRepository, IConfiguration _config, IMembershipTypeRepository membershipTypeRepository)
        {
            this.equipmentRepositry = equipmentRepositry;
            this.suplementRepository = suplementRepository;
            this._config = _config;
            this.membershipTypeRepository = membershipTypeRepository;
    }

        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest req)
        {
            var lineItems = new List<SessionLineItemOptions>();
            foreach(var price in req.Prices.Keys)
            {
                Console.WriteLine(price);
                lineItems.Add(new SessionLineItemOptions
                {
                    Price = price,
                    Quantity = req.Prices[price]
                });
            }
            var options = new SessionCreateOptions
            {
                SuccessUrl = req.SuccessUrl,
                CancelUrl = req.FailureUrl,
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                Mode = "payment",
                LineItems = lineItems
            };

            var service = new SessionService();
            service.Create(options);
            try
            {
                var session = await service.CreateAsync(options);
                return new OkObjectResult(new CreateCheckoutSessionResponse
                {
                    SessionId = session.Id,
                    PublicKey = _config.GetValue<string>("Stripe:PublishableKey")
                });
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return new BadRequestObjectResult(new ErrorResponse
                {
                    ErrorMessage = new ErrorMessage
                    {
                        Message = e.StripeError.Message,
                    }
                });
            }
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct()
        {
            var equipments = await equipmentRepositry.GetEquipmentsAsync(1,100);
            var suplements = await suplementRepository.GetSuplementsAsync(1, 100);
            var memberships = await membershipTypeRepository.GetMembershipTypesAsync();
            var productService = new ProductService();
            var priceService = new PriceService();
            foreach (var e in equipments)
            {
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
            }
            foreach(var s in suplements)
            {
             
                var productOptions = new ProductCreateOptions
                {
                    Name = s.Name,
                
                };

                var product = productService.Create(productOptions);
                s.ProductId = product.Id;
                var priceOptions = new PriceCreateOptions
                {
                    UnitAmount = Convert.ToInt64(s.Price) * 100,
                    Currency = "rsd",

                    Product = product.Id
                };

                var price = priceService.Create(priceOptions);
                s.PriceId = price.Id;
            }

            foreach(var m in memberships)
            {

                var productOptions = new ProductCreateOptions
                {
                    Name = m.Name,
                 
                };

                var product = productService.Create(productOptions);
                m.ProductId = product.Id;
                var priceOptions = new PriceCreateOptions
                {
                    UnitAmount = Convert.ToInt64(m.Price) * 100,
                    Currency = "rsd",

                    Product =product.Id
                };

                var price = priceService.Create(priceOptions);
                m.PriceId = price.Id;
            }
            await equipmentRepositry.SaveChangesAsync();
            return new OkResult();
        }
        /*
        // POST api/<PaymentsController>/webhook
        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new System.IO.StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                 json,
                 Request.Headers["Stripe-Signature"],
                 _config.GetValue<string>("Stripe:WHSecret")
               ); ;

                // Handle the event
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var payment = stripeEvent.Data.Object as PaymentIntent;
                    //Do stuff
                    Console.WriteLine(payment.Customer);
                    Console.WriteLine(payment.CustomerId);
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest();
            }
        }
        */ 
        

    }
}
