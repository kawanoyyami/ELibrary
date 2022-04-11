using Common.Exceptions;
using Entity.Models.Auth;
using Entity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class UserRepository : Repository<User> where User : class, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<User> CreateUser(User user)
        {
            await base.AddAsync(user);

            return user;
        }

        public async Task DeleteUser(long id)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (res == null)
                throw new NotFoundException("User doesn't exist!");
            await Delete(id);
        }
        public async Task<User> GetByUserName(string username)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);
            return res;
        }

        public async Task<User> SingleUserNameAndEmail(string username, string email)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email || x.UserName == username);

            return res;
        }
    }
}
