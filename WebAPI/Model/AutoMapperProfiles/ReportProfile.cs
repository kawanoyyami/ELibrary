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
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<Report, ReportResponseDto>();
            CreateMap<ReportCreateDto, Report>();
            CreateMap<Report, ReportWithProjectDto>()
                .ForMember(x => x.Project, Y => Y.MapFrom(z => z.Project));
        }
    }
}
