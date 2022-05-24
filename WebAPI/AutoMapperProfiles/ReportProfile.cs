using AutoMapper;
using Common.Dto.Report;
using Domain.Models.Reports;

namespace BL.AutoMapperProfiles
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
