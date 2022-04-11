using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.User
{
    public class LoginUserQueryDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
