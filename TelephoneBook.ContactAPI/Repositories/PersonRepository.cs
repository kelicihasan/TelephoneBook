using Microsoft.EntityFrameworkCore;
using TelephoneBook.ContactAPI.Models;
using TelephoneBook.ContactAPI.Repositories.Abstract;

namespace TelephoneBook.ContactAPI.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ContactDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId)
        {
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
