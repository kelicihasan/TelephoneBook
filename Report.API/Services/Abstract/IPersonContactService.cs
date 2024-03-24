using System.Linq.Expressions;
using Report.API.Dtos.Report;
using Report.API.Models;

namespace Report.API.Services.Abstract
{
    public interface IPersonContactService
    {
        Task<List<ReportDto>> GetAll();
        Task Create(PersonContact entity);
    }
}
