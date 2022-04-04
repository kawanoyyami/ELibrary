using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetByName(string name);
        Task<Project> GetById(long id);
        Task<Project> CreateProject(Project project);
        Task DeleteProject(long id);
        Task<ICollection<Report>> GetReports(long id);
        Task<Project> UpdateProject(Project report);
        Task<ICollection<Report>> GetAllUserReports(long id);
    }
}
