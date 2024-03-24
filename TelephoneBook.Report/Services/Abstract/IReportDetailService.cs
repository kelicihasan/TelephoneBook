using System.Linq.Expressions;
using TelephoneBook.ReportAPI.Models;

namespace TelephoneBook.ReportAPI.Services.Abstract
{
    public interface IReportDetailService
    {
        Task<List<ReportDetail>> GetAll();
        Task<ReportDetail> GetById(Guid id);
        void Create(ReportDetail entity);
        Task BulkCreate(List<ReportDetail> entity);
        Task<List<ReportDetail>> GetAllById(Guid id);
    }
}
