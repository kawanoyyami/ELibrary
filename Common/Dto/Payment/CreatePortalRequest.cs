using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Payment
{
    public class CreatePortalRequest
    {
        [Required]
        public string ReturnUrl { get; set; }
    }
}
