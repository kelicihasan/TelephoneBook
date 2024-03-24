using TelephoneBook.ContactAPI.Dtos.Contact;

namespace TelephoneBook.ContactAPI.Services.Abstract
{
    public interface IContactService
    {
        Task<bool> CreateContact(ContactCreateRequestDto requestDto);
    }
}
