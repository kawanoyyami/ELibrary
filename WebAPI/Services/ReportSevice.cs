using AutoMapper;
using Entity.Models;
using Entity.Repository.Interfaces;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ReportSevice : IReportSevice
    {
        private IProjectRepository _projectRepository { get; }
        private IMapper _mapper { get; }
        private IReportRepository _reportRepository { get; }

        public ReportSevice(IProjectRepository projectRepository, IMapper mapper, IReportRepository reportRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ReportResponseDto> GetReport(long id)
        {
            var report = await _reportRepository.GetEntity(id);
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
            var report = await _reportRepository.GetEntity(id);

            await _reportRepository.Delete(report);
        }

        public async Task<UserResponseDto> GetReportUser(long id)
        {
            var user = await _reportRepository.GetReportUser(id);
            var result = _mapper.Map<UserResponseDto>(user);
            return result;
        }

        public async Task CreateReport(ReportCreateDto reportCreateDto)
        {
            var project = await _projectRepository.GetById(reportCreateDto.ProjectId);
            var report = _mapper.Map<Report>(reportCreateDto);
            await _reportRepository.CreateReport(report);
        }

        public async Task<ProjectResponseDto> GetReportProject(long id)
        {
            var project = await _reportRepository.GetReportProject(id);
            var result = _mapper.Map<ProjectResponseDto>(project);
            return result;
        }
    }
}
