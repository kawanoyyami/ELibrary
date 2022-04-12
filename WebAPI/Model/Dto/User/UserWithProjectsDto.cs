using WebAPI.Model.Dto.Project;

namespace WebAPI.Model.Dto.User
{
    public class UserWithProjectsDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<ProjectResponseDto> Projects { get; set; }
    }
}
