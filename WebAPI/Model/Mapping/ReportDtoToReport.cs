using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Report;

namespace WebAPI.Model.Mapping
{
    public class ReportDtoToReport : Profile
    {
        public ReportDtoToReport()
        {
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportResponseDto>();
            CreateMap<ReportCreateDto, Report>();
        }
    }
}
