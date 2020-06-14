using System;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;

namespace Healt_Care_System.Controllers
{
    public class NursesController : Controller
    {

        private MongoDBContext _context;
        private PopulateNurseDegrees _degrees;
        private PopulateGenders _genders;
        private PopulateDepartments _departments;
        private string _table;

        public NursesController()
        {
            _context = new MongoDBContext();
            _degrees = new PopulateNurseDegrees();
            _genders = new PopulateGenders();
            _departments = new PopulateDepartments();
            _table = "Nurses";
        }

        public ActionResult GetData()
        {
            var nurses = _context.LoadRecords<Nurse>(_table);
            return Json(new { data = nurses }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(string id)
        {

           _context.DeleteRecordByIdProperity<Nurse>(_table, id);

            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var nurse = new Nurse();
            nurse.NurseId = GenerateUniqueID();

            var viewModel = new NurseFormViewModel
            {
                Degree=_degrees.GetRecords,
                Departments=_departments.GetRecords,
                Gender=_genders.GetRecords,
                Nurse=nurse
            };

            return View("NurseForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var nurse = _context.LoadRecordByIdProperity<Nurse>(_table, id);

            if (nurse == null)
                return HttpNotFound();
            var viewModel = new NurseFormViewModel
            {

                Nurse = nurse,
                Degree = _degrees.GetRecords,
                Departments=_departments.GetRecords,
                Gender=_genders.GetRecords
        
            };

            return View("NurseForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Nurse nurse)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NurseFormViewModel
                {
                    Nurse =nurse,
                    Departments =_departments.GetRecords,
                    Gender = _genders.GetRecords,
                    Degree=_degrees.GetRecords
                    
                };

                return View("NurseForm", viewModel);
            }

            if (nurse.Id == Guid.Empty)
                _context.InsertRecord(_table, nurse);

            else
            {
                var nurseInDb = _context.LoadRecordByIdProperity<Nurse>(_table, nurse.NurseId);
                nurseInDb.NurseId = nurse.NurseId;
                nurseInDb.NationalId = nurse.NationalId;
                nurseInDb.Phone = nurse.Phone;
                nurseInDb.Salary = nurse.Salary;
                nurseInDb.GendreId = nurse.GendreId;
                nurseInDb.Name = nurse.Name;
                nurseInDb.Address = nurse.Address;
                nurseInDb.EmailAddress = nurse.EmailAddress;
                nurseInDb.DepartmentId = nurse.DepartmentId;
                nurseInDb.DegreeId = nurse.DegreeId;
                nurseInDb.BithDate = nurse.BithDate;

                _context.UPsertRecordByObjectId(_table, nurse.Id, nurse);

            }

            


            return RedirectToAction("Index", "Nurses");
        }


        public ActionResult Details(string id)
        {
            var nurse = _context.LoadRecordByIdProperity<Nurse>(_table, id);
            if (nurse == null)
                return HttpNotFound();

            return View("Details", nurse);

        }

        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
           var nurses = _context.LoadRecords<Nurse>(_table);
            return View(nurses);
        }
    }
}