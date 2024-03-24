using TelephoneBook.ReportAPI.Services.Abstract;

namespace TelephoneBook.ReportAPI.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IPersonContactService PersonContactService { get; }
        IReportDetailService ReportDetailService { get; }
        IReportService ReportService { get; }
    }
}
