using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.User
{
    public class RegisterUserQueryDto
    {
        [Required]
        [MaxLength(32)]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(320)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
