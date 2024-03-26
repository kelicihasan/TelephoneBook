using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Report.Application.Services.Abstract;
using Report.Domain.Entities;
using Report.Persistence.Repositories;
using Shared.Settings;

namespace Report.Persistence.Services
{
    public class ReportDetailService : MongoGenericRepository<ReportDetail>, IReportDetailService
    {
        public ReportDetailService(IOptions<MongoDbSettings> options) : base(options)
        {
        }

        public async Task BulkCreate(List<ReportDetail> entity)
        {
            await base.BulkInsert(entity);
        }
        public async Task<ReportDetail> GetById(Guid id)
        {
            var report = base.GetById(x => x.Id == id);
            if (report == null)
                throw new Exception("Rapor Bilgisi bulunamadı");

            return await report;
        }

        public new async Task<List<ReportDetail>> GetAll()
        {
            var reportList = base.GetAll().Result.ToList();
            if (reportList == null)
                throw new Exception("Rapor bulunamadı");

            return reportList.ToList();
        }
        public async Task<List<ReportDetail>> GetAllById(Guid id)
        {
            var report = base.GetAllById(x => x.ReportId == id).Result;
            if (report == null)
                throw new Exception("Rapor Bilgisi bulunamadı");

            return report;
        }
    }
}
