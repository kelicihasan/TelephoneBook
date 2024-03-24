using Report.API.Services.Abstract;

namespace Report.API.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IPersonContactService PersonContactService { get; }
        IReportDetailService ReportDetailService { get; }
        IReportService ReportService { get; }
    }
}
