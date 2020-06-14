using Healt_Care_System.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models.MedicalTests
{
    public class Tests
    {
        private MongoDBContext _context;

        public Tests()
        {
            _context = new MongoDBContext();
        }


        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        [Required]
        public string  Id { get; set; }

        [Display(Name ="Patient")]
        [Required]
        public string PatientName { get; set; }

        [BsonElement("medicalTestId")]
        [Display(Name ="Medical Test")]
        [Required]
        public int MedicalTestId { get; set; }

        [BsonElement("medicalTestRecord")]
        [Required]
        public string MedicalTestRecord
        {
            get
            {
                var record = _context.LoadRecordByIdProperity<MedicalTest>("MedicalTest", MedicalTestId);
                var name = record.Name;
                return name;
            }   
        }

        [BsonElement("medicalTypeId")]
        [Display(Name ="Medical Type")]
        [Required]
        public int MedicalTypeId { get; set; }

        [BsonElement("medicalTypeRecord")]
        public string MedicalTypeRecord
        {
            get
            {
                var record = _context.LoadRecordByIdProperity<MedicalType>("MedicalType", MedicalTypeId);
                var type = record.Type;
                return type;
            }
        }

        [BsonElement("price")]
        public double Price
        {
            get
            {
                var record = _context.LoadRecordByIdProperity<MedicalType>("MedicalType", MedicalTypeId);
                var price = record.Price;
                return price;
            }
        }


    }
}