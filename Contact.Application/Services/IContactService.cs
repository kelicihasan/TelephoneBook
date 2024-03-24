using Contact.Application.Models.Dtos.Contact;

namespace Contact.Application.Services
{
    public interface IContactService
    {
        Task<bool> CreateContact(ContactCreateRequestDto requestDto);
    }
}
