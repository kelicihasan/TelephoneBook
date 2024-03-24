using Contact.Application.Models;
using Contact.Application.Repositories;
using Contact.Domain.Entities;
using Contact.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Contact.Persistence.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ContactDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId)
        {
            var ss = await base._dbContext.Person
                .Include(x => x.ContactInfos).ToListAsync();

            var data = await base._dbContext.Person
                .Include(x => x.ContactInfos)
                .Where(x => x.Id == personId)
                .ToListAsync();

            return data;
        }

        public async Task<int> RemovePersonContactByPersonId(Guid personId)
        {
            var data = await base._dbContext.ContactInfo
                .Where(x => x.PersonId == personId)
                .FirstAsync();

            _dbContext.ContactInfo.Remove(data);
            return _dbContext.SaveChanges();
        }
    }
}
