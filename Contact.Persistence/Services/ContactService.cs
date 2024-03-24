using AutoMapper;
using Contact.Application.Models;
using Contact.Application.Models.Dtos.Contact;
using Contact.Application.Services;
using Contact.Domain.Entities;
using MassTransit;
using Shared.Events;

namespace Contact.Persistence.Services
{
    public class ContactService : IContactService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<bool> CreateContact(ContactCreateRequestDto requestDto)
        {
            if (requestDto == null)
                throw new Exception("Iletisim bilgileri boş geçilemez.");

            var personDetails = await _unitOfWork.Person.GetById(requestDto.PersonId).ConfigureAwait(false);
            if (personDetails == null)
                throw new Exception("Kişi bilgisi bulunamadı.");

            var _contact = _mapper.Map<ContactInfo>(requestDto);
            await _unitOfWork.Contact.Add(_contact);

            var result = _unitOfWork.Save();

            await PersonContactCreatedEventTrigger(requestDto);

            if (result > 0)
                return true;
            return false;
        }
        private async Task PersonContactCreatedEventTrigger(ContactCreateRequestDto requestDto)
        {
            PersonContactCreatedEvent reportCreatedEvent = new PersonContactCreatedEvent
            {
                Content = requestDto.Content,
                EMailAddress = requestDto.EMailAddress,
                Location = requestDto.Location,
                PersonId = requestDto.PersonId,
                PhoneNumber = requestDto.PhoneNumber
            };

            await _publishEndpoint.Publish(reportCreatedEvent);
        }
    }
}
