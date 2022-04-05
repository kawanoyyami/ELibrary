using Entity.Models;
using Entity.Models.Auth;
using Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class ReportRepository : SQLGenericRepository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task CreateReport(Report report) => await base.Create(report);

        public async Task<Project> GetReportProject(long id)
        {
            var report = await base.GetEntity(id);

            if (report == null)
            {
                return null;
            }

            var project = _context.Set<Project>().FirstOrDefault(p => p.Id == report.ProjectId);

            return project;
        }

        public async Task<User> GetReportUser(long id)
        {
            var project = await GetReportProject(id);
            return _context.Set<User>().FirstOrDefault(p => p.Id == project.Id);
        }
    }
}
