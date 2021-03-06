using System.ComponentModel.DataAnnotations;

namespace Common.Dto.User
{
    public class RegisterUserQueryDto
    {
        [Required]
        [MaxLength(32)]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        [MaxLength(320)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
