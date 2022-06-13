using Stripe;

namespace TeretanaApi.Helper
{
    public interface IProcessStripeEvents
    {
        Task createBasket(Stripe.Checkout.Session session, StripeList<LineItem> lineItems);
        Task addMembership(Stripe.Checkout.Session session, LineItem lineItem);
    }
}
