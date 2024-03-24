using TelephoneBook.ContactAPI.Models;

namespace TelephoneBook.ContactAPI.Repositories.Abstract
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId);
        Task<int> RemovePersonContactByPersonId(Guid personId);
    }
}
