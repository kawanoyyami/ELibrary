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
    public class BookRepository : SQLGenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base (context)
        {

        }

        public async Task<Book> AddBook(Book book)
        {
            await base.Create(book);
            return book;
        }

        public async Task DeleteBook(long id)
        {
            var res = await _context.Set<Book>().FirstOrDefaultAsync(b => b.Id == id);

            await Delete(res);
        }

        public async Task<ICollection<Author>> GetAuthor(long id)
        {
            var res = await _context.Books.Include("Authors").FirstOrDefaultAsync(b => b.Id == id);
            return res.Authors;
        }

        public async Task<Book> GetById(long id)
        {
            var res = await _context.Set<Book>().FirstOrDefaultAsync(b => b.Id == id);
            return res;
        }

        public Task<Book> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            await base.Update(book);
            return book;
        }

    }
}
