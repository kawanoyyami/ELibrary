using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Payment
{
    public class CreateCheckoutSessionRequest
    {
        [Required]
        public string PriceId { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
