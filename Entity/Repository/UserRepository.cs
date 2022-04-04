using Entity.Models;
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
    public class UserRepository : SQLGenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> CreateUser(User user)
        {
            await base.Create(user);
            return user;
        }

        public async Task DeleteUser(long id)
        {
            var res = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (res == null)
                throw new Exception();
            await Delete(res);
        }

        public async Task<User> GetByEmail(string email) => await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetByUserName(string userName) => await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> GetUSerNameAndEmail(string userName, string email) => await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == userName || x.Email == email);
        public async Task<ICollection<Project>> GetProjects(long id)
        {
            var res = await _context.Users.Include("Projects").FirstOrDefaultAsync(u => u.Id == id);
            return res?.Projects;
        }

        public async Task<ICollection<Report>> GetReports(long id)
        {
            var res = await _context.Users.Include("Reports").FirstOrDefaultAsync(u => u.Id == id);
            return (res?.Projects.SelectMany(x => x.Reports))?.ToList();
        }

        
    }
}
