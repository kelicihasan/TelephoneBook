using Report.Application.Repositories.Abstract;
using Report.Application.Services.Abstract;

namespace Report.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonContactService PersonContactService { get; }

        public IReportDetailService ReportDetailService { get; }

        public IReportService ReportService { get; }

        public UnitOfWork(IPersonContactService _PersonContactService, 
            IReportDetailService _ReportDetailService,
            IReportService _ReportService)
        {
            PersonContactService = _PersonContactService;
            ReportDetailService = _ReportDetailService;
            ReportService = _ReportService;
        }
    }
}
