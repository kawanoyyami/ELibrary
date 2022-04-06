using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Report;

namespace WebAPI.Model.Mapping
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportResponseDto>();
            CreateMap<ReportCreateDto, Report>();
        }
    }
}
