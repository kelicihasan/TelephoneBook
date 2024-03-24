using System.Linq.Expressions;
using TelephoneBook.ReportAPI.Models;

namespace TelephoneBook.ReportAPI.Services.Abstract
{
    public interface IReportService
    {
        Task<List<Report>> GetAll();
        Task<Report> GetById(Guid id);
        Task<Report> Create();
        Task Update(Report entity, Expression<Func<Report, bool>> predicate);
    }
}
