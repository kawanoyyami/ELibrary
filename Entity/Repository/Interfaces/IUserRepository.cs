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
        Task<User> GetByUserName(string username);
        Task<User> CreateUser(User user);
        Task<User> SingleUserNameAndEmail(string username, string email);
        Task DeleteUser(long id);
    }
}
