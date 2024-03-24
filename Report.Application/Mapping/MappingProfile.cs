using AutoMapper;
using Report.Application.Dtos.Report;

namespace Report.Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Report.Domain.Entities.Report, CreateReportRequestDto>().ReverseMap();
            CreateMap<Report.Domain.Entities.Report, ReportDto>().ReverseMap();
        }
    }
}
