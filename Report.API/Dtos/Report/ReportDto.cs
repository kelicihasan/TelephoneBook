namespace Report.API.Dtos.Report
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
