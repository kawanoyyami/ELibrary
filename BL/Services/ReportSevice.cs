using AutoMapper;
using BL.Interfaces;
using Common.Dto.Report;
using Common.Exceptions;
using DataAccess.Repository.Interfaces;
using Domain.Models.Reports;

namespace BL.Services
{
    public class ReportSevice : IReportSevice
    {
        private IMapper _mapper { get; }
        private IRepository<Report> _reportRepository { get; }
        private readonly IRepository<Project> _projectRepository;

        public ReportSevice(IMapper mapper, IRepository<Report> reportRepository, IRepository<Project> projectRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ReportResponseDto> GetReport(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);

            if (report is null)
                throw new NotFoundException("Report doesn't exist!");

            var response = _mapper.Map<ReportResponseDto>(report);
            return response;
        }

        public async Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdateDto)
        {
            var res = await _reportRepository.GetByIdAsync(reportUpdateDto.Id);

            if (res == null)
                throw new ValueOutOfRangeException($"Report could not be updated because report with id: {reportUpdateDto.Id} not exist in database!");

            _mapper.Map<ReportUpdateDto>(res);

            await _reportRepository.Update(res);

            return null;
        }

        public async Task DeleteReport(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);

            if (report == null)
                throw new NotFoundException($"Report could not be deleted because report with id: {id} not exist in database!");

            await _reportRepository.Delete(id);
        }
        public async Task CreateReport(ReportCreateDto reportCreateDto)
        {
            var report = _mapper.Map<Report>(reportCreateDto);
            await _reportRepository.AddAsync(report);
        }

        public async Task<ReportWithProjectDto> GetReportWithProjects(long id)
        {
            var project = await _reportRepository.GetByIdWithIncludeAsync(id, r => r.Project);

            if (project is null)
                throw new NotFoundException("Report doesn't exist!");

            var result = _mapper.Map<ReportWithProjectDto>(project);
            return result;
        }
    }
}
