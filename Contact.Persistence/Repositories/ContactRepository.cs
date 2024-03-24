using Contact.Application.Models;
using Contact.Application.Repositories.Abstract;
using Contact.Domain.Entities;
using Contact.Persistence.Context;

namespace Contact.Persistence.Repositories
{
    public class ContactRepository : GenericRepository<ContactInfo>, IContactRepository
    {
        public ContactRepository(ContactDbContext context) : base(context)
        {
        }
    }
}
