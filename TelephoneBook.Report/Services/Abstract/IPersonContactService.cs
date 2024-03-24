using System.Linq.Expressions;
using TelephoneBook.ReportAPI.Dtos.Report;
using TelephoneBook.ReportAPI.Models;

namespace TelephoneBook.ReportAPI.Services.Abstract
{
    public interface IPersonContactService
    {
        Task<List<ReportDto>> GetAll();
        Task Create(PersonContact entity);
    }
}
