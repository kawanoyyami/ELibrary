using Common.Dto.Book;

namespace Common.Dto.Author
{
    public class AuthorWithBooksDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<BookResponseDto> Books { get; set; }
    }
}
