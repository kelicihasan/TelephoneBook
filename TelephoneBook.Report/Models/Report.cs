using MongoDB.Bson.Serialization.Attributes;

namespace TelephoneBook.ReportAPI.Models
{
    public class Report
    {
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReportState { get; set; }
    }
}
