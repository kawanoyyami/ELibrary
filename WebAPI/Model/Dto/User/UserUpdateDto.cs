using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model.Dto.User
{
    public class UserUpdateDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
