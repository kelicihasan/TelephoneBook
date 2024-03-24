using AutoMapper;
using Contact.Application.Dtos.Person.Request;
using Contact.Application.Dtos.Person.Response;
using Contact.Application.Models.Dtos.Contact;
using Contact.Domain.Entities;

namespace Contact.Application.Mapping
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
