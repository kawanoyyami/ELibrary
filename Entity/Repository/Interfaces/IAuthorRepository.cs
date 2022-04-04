using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetByIdAsync(long id);
        Task<Author> GetByName(string name);
        Task<Author> AddAuthor(Author author);
        Task<ICollection<Book>> GetBook(long id);

    }
}
