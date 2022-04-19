using AutoMapper;
using Common.Exceptions;
using Entity.Models;
using Entity.Repository;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ReportSevice : IReportSevice
    {
        private IMapper _mapper { get; }
        private IRepository<Report> _reportRepository { get; }

        public ReportSevice(IMapper mapper, IRepository<Report> reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
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

            if (res is null)
                throw new NotFoundException("Report doesn't exist!");

            res.Name = reportUpdateDto.Name;
            res.Link = reportUpdateDto.Link;
            res.CreatedDate = reportUpdateDto.CreatedDate;

            await _reportRepository.Update(res);

            return null;
        }

        public async Task DeleteReport(long id)
        {
            var report = await _reportRepository.GetByIdAsync(id);

            if(report is null)
                throw new NotFoundException("Report doesn't exist!");

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
