using System;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Healt_Care_System.Entities;

namespace Healt_Care_System.Models
{
    public class Doctor
    {
        private MongoDBContext _context;

        public Doctor()
        {
            _context = new MongoDBContext();


        }
        [BsonId]
        public Guid Id { get; set; }


        [BsonElement("id")]
        [Display(Name = "Id")]
        public string DocId { get; set; }

        [Required]
        [BsonElement("nationalId")]
        [Display(Name = "National Id")]
        public int? NationalId { get; set; }


        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [Required]
        [BsonElement("gendreId")]
        [Display(Name = "Gendre")]
        public int GendreId { get; set; }

        [BsonElement("genderRecord")]
        public Gender GendreRecord
        {
            get
            {
                return _context.LoadRecordByIdProperity<Gender>("Genders", GendreId);

            }
        }

        [Required]
        [BsonElement("address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [BsonElement("birthDate")]
        [Display(Name = "Date of Birth")]
        public DateTime? BithDate { get; set; }

        [Required]
        [BsonElement("salary")]
        public double? Salary { get; set; }

        [BsonElement("specId")]
        [Display(Name = "Specilization")]
        public int SpecId { get; set; }

        [BsonElement("specRecord")]
        public specilization SpecRecord
        {
            get
            {

                return _context.LoadRecordByIdProperity<specilization>("specilizations", SpecId);
            }
        }


        [Required]
        [BsonElement("degreeId")]
        [Display(Name = "Degree")]
        public int DegreeId { get; set; }


        [BsonElement("degreeRecord")]
        public DoctorDegree DegreeRecord
        {
            get
            {

                return _context.LoadRecordByIdProperity<DoctorDegree>("DoctorDegrees", DegreeId);

            }

        }
    
        [Phone]
        [Required]
        [BsonElement("phone")]
        public string Phone { get; set; }

        [EmailAddress]
        [Required]
        [BsonElement("emailAddress")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        public string Title
        {
         get
            {
                return Id == Guid.Empty ? "New Doctor" : "Edit Doctor";
            }           
        }
    }
}