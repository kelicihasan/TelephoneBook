using TelephoneBook.ContactAPI.Dtos.Person.Request;
using TelephoneBook.ContactAPI.Dtos.Person.Response;
using TelephoneBook.ContactAPI.Models;

namespace TelephoneBook.ContactAPI.Services.Abstract
{
    public interface IPersonService
    {
        Task<bool> CreatePerson(PersonCreateRequestDto person);
        Task<IEnumerable<GetPersonDto>> GetAllPerson();
        Task<bool> DeletePerson(Guid personId);
        Task<bool> RemovePersonContactByPersonId(Guid personId);
        Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId);

    }
}
