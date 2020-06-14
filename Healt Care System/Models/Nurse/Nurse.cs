using System;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Healt_Care_System.Entities;

namespace Healt_Care_System.Models
{
    public class Nurse
    {
        private MongoDBContext _context;

        public Nurse()
        {
            _context = new MongoDBContext();
        }


        [BsonId]
        public Guid Id { get; set; }


        [BsonElement("id")]
        [Display(Name = "Id")]
        public string NurseId { get; set; }

        [Required]
        [BsonElement("nationalId")]
        [Display(Name = "National Id")]
        public int? NationalId { get; set; }


        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Gendre")]
        [BsonElement("gendreId")]
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

        [BsonElement("departmentId")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [BsonElement("departmentRecord")]
        public Department DepartmentRecord
        {
            get
            {

                return _context.LoadRecordByIdProperity<Department>("specilizations", DepartmentId);
            }
        }


        [Required]
        [BsonElement("degreeId")]
        [Display(Name = "Degree")]
        public int DegreeId { get; set; }


        [BsonElement("degreeRecord")]
        public NurseDegree DegreeRecord
        {
            get
            {

                return _context.LoadRecordByIdProperity<NurseDegree>("NurseDegrees", DegreeId);

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
                return Id == Guid.Empty ? "New Nurse" : "Edit Nurse";
            }
        }


    }
}