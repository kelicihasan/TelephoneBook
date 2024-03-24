using Contact.Application.Repositories;
using Contact.Application.Repositories.Abstract;
using Contact.Application.Services;
using Contact.Persistence.Context;

namespace Contact.Persistence.Services
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
