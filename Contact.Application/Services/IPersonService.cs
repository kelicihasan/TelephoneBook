using Contact.Application.Dtos.Person.Request;
using Contact.Application.Dtos.Person.Response;
using Contact.Domain.Entities;

namespace Contact.Application.Services
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
