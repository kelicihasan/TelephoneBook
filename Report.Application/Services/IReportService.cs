using System.Linq.Expressions;

namespace Report.Application.Services.Abstract
{
    public interface IReportService
    {
        Task<List<Report.Domain.Entities.Report>> GetAll();
        Task<Report.Domain.Entities.Report> GetById(Guid id);
        Task<Report.Domain.Entities.Report> Create();
        Task Update(Report.Domain.Entities.Report entity, Expression<Func<Report.Domain.Entities.Report, bool>> predicate);
    }
}
