using Common.Dto.Payment;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace BL.Interfaces
{
    public interface IPaymentService
    {
        Task<StripeList<Product>> GetListProducts(long limit);
        Task StripeWebhook(Event stripeEvent);
        Task<Stripe.BillingPortal.Session> CustomerPortal(CreatePortalRequest req, Claim claim);
        Task<Session> CreateCheckoutSession(CreateCheckoutSessionRequest req);
    }
}
