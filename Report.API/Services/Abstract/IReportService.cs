using System.Linq.Expressions;
using Report.API.Models;

namespace Report.API.Services.Abstract
{
    public interface IReportService
    {
        Task<List<Report.API.Models.Report>> GetAll();
        Task<Report.API.Models.Report> GetById(Guid id);
        Task<Report.API.Models.Report> Create();
        Task Update(Report.API.Models.Report entity, Expression<Func<Report.API.Models.Report, bool>> predicate);
    }
}
