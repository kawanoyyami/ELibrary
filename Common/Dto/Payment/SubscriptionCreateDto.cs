using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Payment
{
    public class SubscriptionCreateDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
    }
}
