using AutoMapper;
using Common.Exceptions;
using Entity.Models;
using Entity.Models.Auth;
using Entity.Models.Payment;
using Entity.Repository;
using Microsoft.AspNetCore.Identity;
using Stripe;
using WebAPI.Model.Dto.Payment;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Subscriptionn> _subscriptionRepository;
        public PaymentService(IMapper mapper, UserManager<User> userManager, IRepository<Subscriptionn> subscriptionRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
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

        public async Task StripeWebhook(Event stripeEvent)
        {
            switch (stripeEvent.Type)
            {
                case Events.CustomerSubscriptionCreated:
                    {
                        var service = new CustomerService();
                        var subscription = stripeEvent.Data.Object as Subscription;
                        var customer = await service.GetAsync(subscription!.CustomerId);


                        var subscriptionCreateDto = new SubscriptionCreateDto
                        {
                            Email = customer.Email,
                            StartDateTime = subscription!.CurrentPeriodStart,
                            EndDateTime = subscription.CurrentPeriodEnd
                        };

                        await CreateSubscription(subscriptionCreateDto);

                        break;
                    }
                case Events.CustomerSubscriptionUpdated:
                    {
                        var session = stripeEvent.Data.Object as Stripe.Subscription;
                        Console.WriteLine("*****************Subscription updated*****************");
                        // Update Subsription
                        //await updateSubscription(session);
                        break;
                    }
                case Events.CustomerCreated:
                    {
                        var customer = stripeEvent.Data.Object as Customer;
                        Console.WriteLine("*****************Created new customer*****************");
                        //Do Stuff
                        //await addCustomerIdToUser(customer);
                        break;
                    }
                case Events.InvoicePaymentFailed:
                    Console.WriteLine("*****************Invoice payment failed*****************");
                    break;
                default:
                    Console.WriteLine("***************** Unhandled event type: {0} *****************", stripeEvent.Type);
                    break;
            }

        }
        public async Task<SubscriptionDto> CreateSubscription(SubscriptionCreateDto subscriptionCreateDto)
        {
            var subscription = _mapper.Map<Subscriptionn>(subscriptionCreateDto);

            subscription.User = await _userManager.FindByEmailAsync(subscriptionCreateDto.Email);

            await _subscriptionRepository.AddAsync(subscription);
            await _subscriptionRepository.SaveChangesAsync();

            var result = _mapper.Map<SubscriptionDto>(subscription);

            return result;
        }
    }
}
