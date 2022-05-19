using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace WebAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<StripeList<Product>> GetListProducts(long limit);
    }
}
