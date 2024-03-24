using TelephoneBook.ReportAPI.Dtos.Report;
using TelephoneBook.ReportAPI.Models;
using TelephoneBook.ReportAPI.Repositories;
using TelephoneBook.ReportAPI.Services.Abstract;

namespace TelephoneBook.ReportAPI.Services
{
    public class PersonContactService : MongoGenericRepository<PersonContact>, IPersonContactService
    {
        public async Task Create(PersonContact entity)
        {
           await base.InsertAsync(entity);
        }
        public async Task<List<ReportDto>> GetAll()
        {
            var data = await base.GetAll();

            if (data == null)
                return new List<ReportDto>();

            var result = data
             .GroupBy(s => new  { s.Location })
             .Select(y => new ReportDto
             {
                 Location = y.Key.Location,
                 PersonCount = y.Count(),
                 PhoneNumberCount = y.Count()
             }).ToList();

            return result;
        }
    }
}
