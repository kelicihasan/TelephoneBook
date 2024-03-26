using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Options;
using Report.Application.Services.Abstract;
using Report.Domain.Enums;
using Report.Persistence.Repositories;
using Shared.Events;
using Shared.Settings;
using System.Linq.Expressions;

namespace Report.Persistence.Services
{
    public class ReportService : MongoGenericRepository<Report.Domain.Entities.Report>, IReportService
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public ReportService(IMapper mapper,
            IPublishEndpoint publishEndpoint,
            IOptions<MongoDbSettings> options) : base(options)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Report.Domain.Entities.Report> Create()
        {
            var reportId = await CreateReport();

            if (string.IsNullOrEmpty(reportId.ToString()))
                throw new Exception("Talep alınırken bir hata ile karşılaşıldı");

            var result = base.GetById(x => x.Id == reportId);
            if (result == null)
                throw new Exception("Talep alınırken bir hata ile karşılaşıldı");

            return await result;
        }

        public async Task<Report.Domain.Entities.Report> GetById(Guid id)
        {
            var report = base.GetById(x => x.Id == id);
            if (report == null)
                throw new Exception("Rapor Bilgisi bulunamadı");

            return await report;
        }

        public new async Task<List<Report.Domain.Entities.Report>> GetAll()
        {
            var reportList = await base.GetAll().ConfigureAwait(false);
            if (reportList == null)
                throw new Exception("Rapor bulunamadı");

            return reportList.ToList();
        }

        public new async Task Update(Report.Domain.Entities.Report entity, Expression<Func<Report.Domain.Entities.Report, bool>> predicate)
        {
            if (entity == null)
                throw new Exception("Güncelleme yapılacak rapor bulunamadı");

            await base.Update(entity, predicate);
        }

        private async Task<Guid> CreateReport()
        {
            var reportId = Guid.NewGuid();
            var report = new Report.Domain.Entities.Report
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
