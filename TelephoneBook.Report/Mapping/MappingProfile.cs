using AutoMapper;
using TelephoneBook.ReportAPI.Dtos.Report;
using TelephoneBook.ReportAPI.Models;

namespace TelephoneBook.ReportAPI.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, CreateReportRequestDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
