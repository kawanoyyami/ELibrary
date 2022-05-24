using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Stripe;
using Stripe.Checkout;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BL.Interfaces;
using Domain.Models.Auth;
using DataAccess.Repository.Interfaces;
using Domain.Models.Subscriptio;
using Common.Dto.Payment;

namespace BL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Subscriptionn> _subscriptionRepository;
        private readonly IRepository<User> _userRepository;
        public PaymentService(IMapper mapper, UserManager<User> userManager, IRepository<Subscriptionn> subscriptionRepository, IRepository<User> repository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = repository;
        }

        public async Task<StripeList<Product>> GetListProducts(long limit)
        {

            var options = new ProductListOptions
            {
                Limit = limit,
                Expand = new List<string> { "data.default_price" }
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(options);

            return products;
        }

        public async Task StripeWebhook(Event stripeEvent)
        {

            switch (stripeEvent.Type)
            {
                case Events.CustomerCreated:
                    {
                        var customer = stripeEvent.Data.Object as Customer;
                        var user = await _userManager.FindByEmailAsync(customer!.Email);

                        user.StripeCustomerID = customer.Id;

                        await _userManager.RemoveFromRoleAsync(user, "FreeUser");
                        await _userManager.AddToRoleAsync(user, "PaidUser");

                        await _userRepository.Update(user);

                        await _userRepository.SaveChangesAsync();

                        break;
                    }
                case Events.CustomerSubscriptionCreated:
                    {

                        //var service = new CustomerService();
                        //var subscription = stripeEvent.Data.Object as Subscription;
                        //var customer = await service.GetAsync(subscription!.CustomerId);

                        //var subscriptionCreateDto = new SubscriptionCreateDto
                        //{
                        //    Email = customer.Email,
                        //    StartDateTime = subscription.CurrentPeriodStart,
                        //    EndDateTime = subscription.CurrentPeriodEnd
                        //};
                        Console.WriteLine("Subscription Created");
                        //await CreateSubscription(subscriptionCreateDto);

                        break;
                    }
                case Events.CustomerSubscriptionUpdated:
                    {
                        var session = stripeEvent.Data.Object as Stripe.Subscription;
                        Console.WriteLine("Subscription updated");
                        // Update Subsription
                        //await updateSubscription(session);
                        break;
                    }
                case Events.InvoicePaymentFailed:
                    Console.WriteLine("Invoice payment failed");
                    break;
                default:
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
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

        public async Task<Stripe.BillingPortal.Session> CustomerPortal(CreatePortalRequest req, Claim claim)
        {

            var userFromDb = await _userManager.FindByIdAsync(claim.Value);

            var options = new Stripe.BillingPortal.SessionCreateOptions
            {
                Customer = userFromDb.StripeCustomerID,
                ReturnUrl = req.ReturnUrl,
            };

            var service = new Stripe.BillingPortal.SessionService();
            var session = await service.CreateAsync(options);

            return session;
        }

        public async Task<Session> CreateCheckoutSession(CreateCheckoutSessionRequest req)
        {
            var user = await _userManager.FindByIdAsync(req.UserId.ToString());

            var option = new SessionCreateOptions
            {
                SuccessUrl = "http://localhost:3000/successl",
                CancelUrl = "http://localhost:3000/failure",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = req.PriceId,
                        Quantity = 1,
                    },
                },
                CustomerEmail = user.StripeCustomerID is null ? user.Email : null,
                Customer = user.StripeCustomerID,

            };

            var service = new SessionService();
            var session = await service.CreateAsync(option);

            return session;
        }
    }
}
