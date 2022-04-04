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
    public class ProjectRepository : SQLGenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Project> CreateProject(Project project)
        {
            await base.Create(project);
            return project;
        }

        public async Task DeleteProject(long id)
        {
            var res = await _context.Set<Project>().FirstOrDefaultAsync(u => u.Id == id);
            await base.Delete(res);
        }

        public Task<ICollection<Report>> GetAllUserReports(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetById(long id)
        {
            var res = await _context.Set<Project>().FirstOrDefaultAsync<Project>(u => u.Id == id);
            return res;
        }

        public async Task<Project> GetByName(string name) => await _context.Set<Project>().FirstOrDefaultAsync<Project>(u => u.Name == name);

        public async Task<ICollection<Report>> GetReports(long id)
        {
            var res = await _context.Projects.Include("Reports").FirstOrDefaultAsync(u => u.Id==id);
            return res.Reports;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            await base.Update(project);
            return project;
        }
    }
}
