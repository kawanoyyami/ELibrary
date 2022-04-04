using Entity.Models;
using Entity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class AuthorRepository :SQLGenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Author> AddAuthor(Author author)
        {
            await base.Create(author);
            return author;
        }

        public async Task<ICollection<Book>> GetBook(long id)
        {
            var res = await _context.Authors.Include("Books").FirstOrDefaultAsync(b => b.Id == id);
            return res.Books;
        }

        public async Task<Author> GetByIdAsync(long id)
        {
            var res = await _context.Set<Author>().FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task<Author> GetByName(string name) => await _context.Set<Author>().FirstOrDefaultAsync(x => x.FullName == name);
    }
}
