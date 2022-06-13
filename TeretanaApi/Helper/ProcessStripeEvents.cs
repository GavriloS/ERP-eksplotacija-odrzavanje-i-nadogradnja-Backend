using AutoMapper;
using Stripe;
using Stripe.Checkout;
using TeretanaApi.Data.Interfaces;
using TeretanaApi.Entities;

namespace TeretanaApi.Helper
{
    public class ProcessStripeEvents : IProcessStripeEvents
    {

        private readonly IBasketRepository basketRepository;
        private readonly ISuplementRepository suplementRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IMembershipRepository membershipRepository;
        private readonly IMembershipTypeRepository membershipTypeRepository;
        private readonly IMapper mapper;

        public ProcessStripeEvents(IBasketRepository basketRepository, ISuplementRepository suplementRepository, IEquipmentRepository equipmentRepository, IMapper mapper, IMembershipRepository membershipRepository,
            IMembershipTypeRepository membershipTypeRepository)
        {
            this.basketRepository = basketRepository;
            this.suplementRepository = suplementRepository;
            this.equipmentRepository = equipmentRepository;
            this.membershipRepository = membershipRepository;
            this.membershipTypeRepository = membershipTypeRepository;
            this.mapper = mapper;
        }

   

        public async Task createBasket(Stripe.Checkout.Session session,StripeList<LineItem> lineItems)
        {
            var basket = new Basket();
            basket.DateTimeOfPurchase = DateTime.Now;
            basket.UserId = Guid.Parse(session.ClientReferenceId);
            basket =  await basketRepository.CreateBasketAsync(basket);
            basket.Suplements = new List<BasketSuplement>();
            basket.Equipments = new List<BasketEquipment>();
            foreach(var lineItem in lineItems)
            {
               
                var e = await equipmentRepository.GetEquipmentByPriceIdAsync(lineItem.Price.Id);
                if(e == null)
                {
                    var s = await suplementRepository.GetSuplementByPriceIdAsync(lineItem.Price.Id);

                    var se = new BasketSuplement();
                    se.BasketId = basket.BasketId;
                    se.SuplementId = s.SuplementId;
                    se.Quantity = (int)lineItem.Quantity;
                    basket.Suplements.Add(se);
                }
                else
                {
                    var be = new BasketEquipment();
                    be.BasketId = basket.BasketId;
                    be.EquipmentId = e.EquipmentId;
                    be.Quantity = (int)lineItem.Quantity;
                    basket.Equipments.Add(be);
                }

            }
   
            await basketRepository.SaveChangesAsync();
            return;
        }

        public async Task addMembership(Session session, LineItem lineItem)
        {
            var membership = new Membership();
            membership.DateTimeOfPayment = DateTime.Now;
            membership.UserId = Guid.Parse(session.ClientReferenceId);
            var membershipType = await membershipTypeRepository.GetMembershipTypeByPriceId(lineItem.Price.Id);

            membership.MembershipTypeId = membershipType.MembershipTypeId;

            await membershipRepository.CreateMembershipAsync(membership);
            await membershipRepository.SaveChangesAsync();
            return;

        }
    }
}
