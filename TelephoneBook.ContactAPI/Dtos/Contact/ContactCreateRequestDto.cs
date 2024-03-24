using TelephoneBook.ContactAPI.Models;

namespace TelephoneBook.ContactAPI.Dtos.Contact
{
    public class ContactCreateRequestDto
    {
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
