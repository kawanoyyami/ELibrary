namespace WebAPI.Model.Dto.Author
{
    public class AuthorCreateDto
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string? AreaOfInteresnt { get; set; }
    }
}
