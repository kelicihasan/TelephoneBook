using Shared.Events.Common;

namespace Shared.Events
{
    public class PersonContactCreatedEvent : IEvent
    {
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
