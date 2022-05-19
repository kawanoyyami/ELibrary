using Common.Exceptions;
using Entity.Models.Auth;
using Entity.Models.Payment;
using Entity.Repository;
using Microsoft.AspNetCore.Identity;
using Stripe;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService(IRepository<User> _userRepository, UserManager<User> userManager)
        {

        }

        public async Task<StripeList<Product>> GetListProducts(long limit)
        {

            var options = new ProductListOptions
            {
                Limit = limit,
                Expand = new List<string> { "data.default_price"}
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(options);

            return products;
        }
    }
}
