using Report.API.Dtos.Report;
using Report.API.Models;
using Report.API.Repositories;
using Report.API.Services.Abstract;

namespace Report.API.Services
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
