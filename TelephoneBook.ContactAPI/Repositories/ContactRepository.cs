using TelephoneBook.ContactAPI.Models;
using TelephoneBook.ContactAPI.Repositories.Abstract;

namespace TelephoneBook.ContactAPI.Repositories
{
    public class ContactRepository : GenericRepository<ContactInfo>, IContactRepository
    {
        public ContactRepository(ContactDbContext context) : base(context)
        {
        }
    }
}
