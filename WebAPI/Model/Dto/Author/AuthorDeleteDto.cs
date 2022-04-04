namespace WebAPI.Model.Dto.Author
{
    public class AuthorDeleteDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string? AreaOfInteresnt { get; set; }
    }
}
