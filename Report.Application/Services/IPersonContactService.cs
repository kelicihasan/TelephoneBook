using Report.Application.Dtos.Report;
using Report.Domain.Entities;

namespace Report.Application.Services.Abstract
{
    public interface IPersonContactService
    {
        Task<List<ReportDto>> GetAll();
        Task Create(PersonContact entity);
    }
}
