using AutoMapper;
using Entity.Models;
using Entity.Repository;
using Entity.Repository.Interfaces;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ReportSevice : IReportSevice
    {
        private IRepository<Project> _projectRepository { get; }
        private IMapper _mapper { get; }
        private IRepository<Report> _reportRepository { get; }

        public ReportSevice(IRepository<Project> projectRepository, IMapper mapper, IRepository<Report> reportRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ReportResponseDto> GetReport(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            var response = _mapper.Map<ReportResponseDto>(report);
            return response;
        }

        public async Task<ReportResponseDto> UpdateReport(ReportUpdateDto reportUpdateDto)
        {
            var report = _mapper.Map<Report>(reportUpdateDto);
            await _reportRepository.Update(report);
            var response = _mapper.Map<ReportResponseDto>(reportUpdateDto);
            return response;
        }

        public async Task DeleteReport(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);

            await _reportRepository.Delete(id);
        }

        public async Task<UserResponseDto> GetReportUser(long id)
        {
            //@TO-Do reapair
            var user = await _reportRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserResponseDto>(user);
            return result;
        }

        public async Task CreateReport(ReportCreateDto reportCreateDto)
        {
            var project = await _projectRepository.GetByIdAsync(reportCreateDto.ProjectId);
            var report = _mapper.Map<Report>(reportCreateDto);
            await _reportRepository.AddAsync(report);
        }

        public async Task<ProjectResponseDto> GetReportProject(long id)
        {
            var project = await _reportRepository.GetByIdAsync(id);
            //TO-DO repair
            var result = _mapper.Map<ProjectResponseDto>(project);
            return result;
        }
    }
}
