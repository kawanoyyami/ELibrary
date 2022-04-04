namespace WebAPI.Model.Dto.Book
{
    public class BookUpdateDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
    }
}
