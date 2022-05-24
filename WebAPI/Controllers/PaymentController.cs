using BL.Interfaces;
using Common.Dto.Payment;
using Common.StripeErrorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly StripeSettings _stripeSettings;
        public PaymentController(IPaymentService paymentService, IOptions<StripeSettings> stripeSettings)
        {
            _paymentService = paymentService;
            _stripeSettings = stripeSettings.Value;
        }

        [HttpGet("products/{NumberOfProducts}")]
        [Authorize]
        public async Task<IActionResult> Products(long NumberOfProducts)
        {
            var result = await _paymentService.GetListProducts(NumberOfProducts);

            return Ok(result);
        }

        [HttpPost("create-checkout-session")]
        public async Task<ActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest req)
        {
            var session = await _paymentService.CreateCheckoutSession(req);

            return Ok(new { SessionId = session.Id });
        }

        [Authorize]
        [HttpPost("customer-portal")]
        public async Task<IActionResult> CustomerPortal([FromBody] CreatePortalRequest req)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var claim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            var session = await _paymentService.CustomerPortal(req, claim);

            return Ok(new { url = session.Url });
        }

        [AllowAnonymous]
        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _stripeSettings.WHSecret
            );

            await _paymentService.StripeWebhook(stripeEvent);

            return Ok();
        }
    }
}

