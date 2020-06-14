using System;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;

namespace Healt_Care_System.Controllers
{
    public class DoctorsController : Controller
    {
        private PopulateSpecilizations _specs;
        private PopulateDoctorDegrees _degrees;
        private PopulateGenders _genders;
        private MongoDBContext _context;
        private string _table;

        public DoctorsController()
        {
           
            _context = new MongoDBContext();
            _specs = new PopulateSpecilizations();
            _degrees = new PopulateDoctorDegrees();
            _genders = new PopulateGenders();   
            _table = "Doctors";
        }

        public ActionResult GetData()
        {
            var doctors = _context.LoadRecords<Doctor>(_table);
            return Json(new { data = doctors }, JsonRequestBehavior.AllowGet);
        }
 
        [HttpPost]
        public ActionResult Delete(string id)
        {
           

            _context.DeleteRecordByIdProperity<Doctor>(_table, id);


            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult New()
        {
            var doctor = new Doctor();
            doctor.DocId = GenerateUniqueID();

            var viewModel = new DoctorFormViewModel
            {
                Doctor = doctor,
                Degree= _degrees.GetRecords,
                specs= _specs.GetRecords,
                Gender= _genders.GetRecords,
            };

            return View("DoctorForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var doctor = _context.LoadRecordByIdProperity<Doctor>(_table, id);

            if (doctor == null)
                return HttpNotFound();
            var viewModel = new DoctorFormViewModel
            {
                Doctor = doctor,
                Gender = _genders.GetRecords,
                Degree = _degrees.GetRecords,
                specs = _specs.GetRecords
            };

            return View("DoctorForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DoctorFormViewModel
                {
                    Doctor = doctor,
                    Gender = _genders.GetRecords,
                    Degree = _degrees.GetRecords,
                    specs = _specs.GetRecords
                };

                return View("DoctorForm", viewModel);
            }

            if (doctor.Id == Guid.Empty)
                _context.InsertRecord(_table, doctor);

            else
            {
                var DoctorInDb = _context.LoadRecordByIdProperity<Doctor>(_table, doctor.DocId);
                DoctorInDb.DocId = doctor.DocId;
                DoctorInDb.Name = doctor.Name;
                DoctorInDb.Address = doctor.Address;
                DoctorInDb.Salary = doctor.Salary;
                DoctorInDb.NationalId = doctor.NationalId;
                DoctorInDb.Phone = doctor.Phone;
                DoctorInDb.BithDate = doctor.BithDate;
                DoctorInDb.EmailAddress = doctor.EmailAddress;
                DoctorInDb.SpecId = doctor.SpecId;
                DoctorInDb.GendreId  = doctor.GendreId;
                DoctorInDb.DegreeId = doctor.DegreeId;

                _context.UPsertRecordByObjectId(_table, doctor.Id, doctor);
            }

            return RedirectToAction("Index", "Doctors");
        }

        public ActionResult Details(string id)
        {
            var doctor = _context.LoadRecordByIdProperity<Doctor>(_table, id);
            if (doctor == null)
                return  HttpNotFound();

            return View("Details", doctor);

        }

        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
            var doctors = _context.LoadRecords<Doctor>(_table);

            return View(doctors);
        }

    }
}