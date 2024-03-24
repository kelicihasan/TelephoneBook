using MongoDB.Bson.Serialization.Attributes;

namespace TelephoneBook.ReportAPI.Models
{
    public class PersonContact
    {
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid Id { get; set; }
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string EMailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
