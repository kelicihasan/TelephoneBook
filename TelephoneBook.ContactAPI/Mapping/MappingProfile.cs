using AutoMapper;
using TelephoneBook.ContactAPI.Dtos.Contact;
using TelephoneBook.ContactAPI.Dtos.Person.Request;
using TelephoneBook.ContactAPI.Dtos.Person.Response;
using TelephoneBook.ContactAPI.Models;

namespace TelephoneBook.ContactAPI.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonCreateRequestDto>().ReverseMap();
            CreateMap<ContactInfo, ContactCreateRequestDto>().ReverseMap();
            CreateMap<Person, GetPersonDto>().ReverseMap();
        }
    }
}
