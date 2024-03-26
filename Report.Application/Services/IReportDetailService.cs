using System.Linq.Expressions;
using Report.Domain.Entities;

namespace Report.Application.Services.Abstract
{
    public interface IReportDetailService
    {
        Task<List<ReportDetail>> GetAll();
        Task<ReportDetail> GetById(Guid id);
        Task BulkCreate(List<ReportDetail> entity);
        Task<List<ReportDetail>> GetAllById(Guid id);
    }
}
