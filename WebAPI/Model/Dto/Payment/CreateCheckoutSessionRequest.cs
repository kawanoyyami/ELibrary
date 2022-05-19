using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.Payment
{
    public class CreateCheckoutSessionRequest
    {
        [Required]
        public string PriceId { get; set; }
    }
}
