using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models.MedicalTests
{
    public class MedicalType
    {
        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("medicalTestId")]
        public int MedicalTestId { get; set; }
    }
}