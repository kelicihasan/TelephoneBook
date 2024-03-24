using AutoMapper;
using MassTransit;
using Shared.Events;
using System.Linq.Expressions;
using Report.API.Dtos.Report;
using Report.API.Enums;
using Report.API.Models;
using Report.API.Repositories;
using Report.API.Services.Abstract;

namespace Report.API.Services
{
    public class ReportService : MongoGenericRepository<Report.API.Models.Report>, IReportService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IPublishEndpoint _publishEndpoint;
        public ReportService(IMapper mapper,
            IConfiguration configuration,
            IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _configuration = configuration;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<Report.API.Models.Report> Create()
        {
            var reportId = await CreateReport();

            if (string.IsNullOrEmpty(reportId.ToString()))
                throw new Exception("Talep alınırken bir hata ile karşılaşıldı");

            var result = base.GetById(x => x.Id == reportId);
            if (result == null)
                throw new Exception("Talep alınırken bir hata ile karşılaşıldı");

            return await result;
        }

        public async Task<Report.API.Models.Report> GetById(Guid id)
        {
            var report = base.GetById(x => x.Id == id);
            if (report == null)
                throw new Exception("Rapor Bilgisi bulunamadı");

            return await report;
        }

        public new async Task<List<Report.API.Models.Report>> GetAll()
        {
            var reportList = await base.GetAll().ConfigureAwait(false);
            if (reportList == null)
                throw new Exception("Rapor bulunamadı");

            return reportList.ToList();
        }

        public new async Task Update(Report.API.Models.Report entity, Expression<Func<Report.API.Models.Report, bool>> predicate)
        {
            if (entity == null)
                throw new Exception("Güncelleme yapılacak rapor bulunamadı");

            await base.Update(entity, predicate);
        }

        private async Task<Guid> CreateReport()
        {
            var reportId = Guid.NewGuid();
            var report = new Report.API.Models.Report
            {
                Id = reportId,
                ReportState = ReportStatus.Hazirlaniyor.ToString(),
                RequestDate = DateTime.Now
            };
            await base.InsertAsync(report);

            await _publishEndpoint.Publish(new ReportCreateEvent { ReportId = reportId });

            return await Task.FromResult(reportId);
        }
    }
}
