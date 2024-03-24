using TelephoneBook.ContactAPI.Repositories.Abstract;

namespace TelephoneBook.ContactAPI.Services.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Person { get; }
        IContactRepository Contact { get; }
        int Save();
    }
}
