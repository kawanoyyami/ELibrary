using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<Book> GetById(long id);
        Task<Book> GetByTitle(string title);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<ICollection<Author>> GetAuthor(long id);
        Task DeleteBook(long id);
    }
}
