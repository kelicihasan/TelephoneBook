using TelephoneBook.ReportAPI.Models;

namespace TelephoneBook.ReportAPI.Dtos.Report
{
    public class CreateReportRequestDto
    {
        public DateTime RequestDate { get; set; }
        public string ReportState { get; set; }
    }
}
