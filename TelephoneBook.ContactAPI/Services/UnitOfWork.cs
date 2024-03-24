using Microsoft.EntityFrameworkCore;
using TelephoneBook.ContactAPI.Models;
using TelephoneBook.ContactAPI.Repositories.Abstract;
using TelephoneBook.ContactAPI.Services.Abstract;

namespace TelephoneBook.ContactAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactDbContext _dbContext;
        public IPersonRepository Person { get; }
        public IContactRepository Contact { get; }

        public UnitOfWork(ContactDbContext dbContext,
                            IPersonRepository _Person, IContactRepository _Contact)
        {
            _dbContext = dbContext;
            Person = _Person;
            Contact = _Contact;
        }
        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
