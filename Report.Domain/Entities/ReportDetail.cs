﻿using MongoDB.Bson.Serialization.Attributes;

namespace Report.Domain.Entities
{
    public class ReportDetail
    {
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.CSharpLegacy)]
        public Guid ReportId { get; set; }
    }
}
