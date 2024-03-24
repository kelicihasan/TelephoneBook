using MongoDB.Bson.Serialization.Attributes;

namespace Report.Domain.Entities
{
    public class Report
    {
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReportState { get; set; }
    }
}
