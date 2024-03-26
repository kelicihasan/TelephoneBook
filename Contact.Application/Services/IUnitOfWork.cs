using Contact.Application.Repositories;
using Contact.Application.Repositories.Abstract;

namespace Contact.Application.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Person { get; }
        IContactRepository Contact { get; }
        bool Save();
    }
}
