using Common.Dto.Project;
using System.ComponentModel.DataAnnotations;

namespace Common.Dto.User
{
    public class UserWithProjectsDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<ProjectResponseDto> Projects { get; set; }
    }
}
