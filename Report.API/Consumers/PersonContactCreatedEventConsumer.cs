using MassTransit;
using Report.Application.Services.Abstract;
using Report.Domain.Entities;
using Shared.Events;

namespace Report.API.Consumers
{
    public class PersonContactCreatedEventConsumer : IConsumer<PersonContactCreatedEvent>
    {
        readonly IPersonContactService _personContactService;

        public PersonContactCreatedEventConsumer(IPersonContactService personContactService)
        {
            _personContactService = personContactService;
        }

        public async Task Consume(ConsumeContext<PersonContactCreatedEvent> context)
        {
            var personContact = new PersonContact
            {
                Content = context.Message.Content,
                EMailAddress = context.Message.EMailAddress,
                Location = context.Message.Location,
                PersonId = context.Message.PersonId,
                PhoneNumber = context.Message.PhoneNumber
            };

            await _personContactService.Create(personContact);
            await Task.FromResult(0);
        }
    }
}
