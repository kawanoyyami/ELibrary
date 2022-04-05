using Entity.Models;
using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<User> GetReportUser(long id);
        Task CreateReport(Report report);
        Task<Project> GetReportProject(long id);
    }
}
