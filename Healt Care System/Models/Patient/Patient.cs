using Healt_Care_System.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models
{
    public class Patient
    {
        private MongoDBContext _context;

        public Patient()
        {
            _context = new MongoDBContext();
        }

        [BsonId]
        public Guid _Id { get; set; }

        [Required]
        [BsonElement("id")]
        public string Id { get; set; }

        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [Required]
        [BsonElement("age")]    
        public int? Age { get; set; }

        [Display(Name ="Blood Type")]
        [BsonElement("bloodType")]
        public string BloodType { get; set; }

        [Required]
        [Display(Name = "job")]        
        public string Job { get; set; }

        [Required]
        [Phone]
        [BsonElement("phone")]
        public string Phone { get; set; }

        [Required]
        [BsonElement("address")]
        public string Address { get; set; }
       
        [EmailAddress]
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("detectionId")]
        [Display(Name ="Detection")]
        public int DetectionId { get; set; }

        [BsonElement("detectionRecord")]
        public specilization DetectionRecord
        {
            get
            {
                return _context.LoadRecordByIdProperity<specilization>("specilizations", DetectionId);
            }
        }

        [BsonElement("notes")]
        public string Notes { get; set; }

        public string Title
        {
            get
            {
                return _Id == Guid.Empty ? "New Patient" : "Edit Patient";
            }
        }

    }
}