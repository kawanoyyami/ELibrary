using Entity.Models;
using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
        Task<User> CreateUser(User user);
        Task<User> GetUSerNameAndEmail(string userName, string email);
        Task DeleteUser(long id);
        Task<ICollection<Project>> GetProjects(long id);
        Task<ICollection<Report>> GetReports(long id);
    }
}
