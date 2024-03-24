using Report.Application.Services.Abstract;

namespace Report.Application.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IPersonContactService PersonContactService { get; }
        IReportDetailService ReportDetailService { get; }
        IReportService ReportService { get; }
    }
}
