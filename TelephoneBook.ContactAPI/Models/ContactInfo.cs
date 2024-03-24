using System.Text.Json.Serialization;

namespace TelephoneBook.ContactAPI.Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
