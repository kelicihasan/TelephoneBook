namespace TelephoneBook.ContactAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
