using Microsoft.Extensions.Options;
using Report.Application.Dtos.Report;
using Report.Application.Services.Abstract;
using Report.Domain.Entities;
using Report.Persistence.Repositories;
using Shared.Settings;

namespace Report.Persistence.Services
{
    public class PersonContactService : MongoGenericRepository<PersonContact>, IPersonContactService
    {
        public PersonContactService(IOptions<MongoDbSettings> options) : base(options)
        {
        }

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
