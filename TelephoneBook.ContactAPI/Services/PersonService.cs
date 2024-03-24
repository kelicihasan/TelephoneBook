using AutoMapper;
using System.Security.AccessControl;
using TelephoneBook.ContactAPI.Dtos.Person.Request;
using TelephoneBook.ContactAPI.Dtos.Person.Response;
using TelephoneBook.ContactAPI.Models;
using TelephoneBook.ContactAPI.Services.Abstract;

namespace TelephoneBook.ContactAPI.Services
{
    public class PersonService : IPersonService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreatePerson(PersonCreateRequestDto person)
        {
            if (person == null)
                throw new Exception("Kişi Adı ve Soyadı Boş Geçilemez.");

            var _person = _mapper.Map<Person>(person);
            await _unitOfWork.Person.Add(_person);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeletePerson(Guid personId)
        {
            if (string.IsNullOrEmpty(personId.ToString()))
                throw new Exception("Id bilgisi boş Geçilemez.");

            var personDetails = await _unitOfWork.Person.GetById(personId);
            if (personDetails == null)
                throw new Exception("Id bilgisi boş Geçilemez.");

            _unitOfWork.Person.Delete(personDetails);
            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<GetPersonDto>> GetAllPerson()
        {
            var personList = await _unitOfWork.Person.GetAll();
            if (personList == null)
                throw new Exception("Kişi listesi bulunamadı.");

            var result = _mapper.Map<List<GetPersonDto>>(personList);

            return result;
        }

        public async Task<bool> RemovePersonContactByPersonId(Guid personId)
        {
            var result = await _unitOfWork.Person.RemovePersonContactByPersonId(personId);

            if (result > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<Person>> GetPersonContactsByPersonId(Guid personId)
        {
            var result = await _unitOfWork.Person.GetPersonContactsByPersonId(personId);

            if (result.Any())
                throw new Exception("Kişiye ait iletişim bilgisi bulunamadı.");
            return result;

        }
    }
}
