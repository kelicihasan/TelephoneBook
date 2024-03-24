using AutoMapper;
using Report.API.Dtos.Report;

namespace Report.API.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Report.API.Models.Report, CreateReportRequestDto>().ReverseMap();
            CreateMap<Report.API.Models.Report, ReportDto>().ReverseMap();
        }
    }
}
