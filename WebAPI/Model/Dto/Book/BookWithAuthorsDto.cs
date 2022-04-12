using Entity.Models;

namespace WebAPI.Model.Dto.Book
{
    public class BookWithAuthorsDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<AuthorResponseDto> Authors { get; set; }
    }
}
