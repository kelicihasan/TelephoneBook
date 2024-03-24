using Report.API.Models;

namespace Report.API.Dtos.Report
{
    public class CreateReportRequestDto
    {
        public DateTime RequestDate { get; set; }
        public string ReportState { get; set; }
    }
}
