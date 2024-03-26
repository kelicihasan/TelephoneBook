using Contact.Application.Models;
using Contact.Domain.Entities;

namespace Contact.Application.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId);
        Task<bool> RemovePersonContactByPersonId(Guid personId);
    }
}
