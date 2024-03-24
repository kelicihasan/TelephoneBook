using TelephoneBook.ReportAPI.Repositories.Abstract;
using TelephoneBook.ReportAPI.Services.Abstract;

namespace TelephoneBook.ReportAPI.Repositories
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
