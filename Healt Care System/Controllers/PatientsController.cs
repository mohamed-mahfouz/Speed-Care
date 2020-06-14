using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;

namespace Healt_Care_System.Controllers
{
    public class PatientsController : Controller
    {

        private MongoDBContext _context;
        private PopulateSpecilizations _spec;
        private string _table;

        public PatientsController()
        {
            _context = new MongoDBContext();
            _spec = new PopulateSpecilizations();
            _table = "Patients";
        }

        public ActionResult GetData()
        {
            var patient = _context.LoadRecords<Patient>(_table);
            return Json(new { data = patient }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetDataForAutoComplete()
        {

            var patients = _context.LoadRecords<Patient>(_table);
            return new JsonResult { Data = patients, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {

            _context.DeleteRecordByIdProperity<Patient>(_table, id);

            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var patient = new Patient();
            patient.Id = GenerateUniqueID();

            var viewModel = new PatientFormViewModel
            {
                patient=patient,
                Detection = _spec.GetRecords

            };

            return View("PatientForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var patient = _context.LoadRecordByIdProperity<Patient>(_table, id);

            if (patient == null)
                return HttpNotFound();

            var viewModel = new PatientFormViewModel
            {

                patient = patient,
                Detection = _spec.GetRecords
            };

            return View("PatientForm", viewModel);
        }

        public ActionResult Details(string id)
        {
            var patient = _context.LoadRecordByIdProperity<Patient>(_table, id);
            if (patient == null)
                return HttpNotFound();

            return View("Details", patient);

        }


        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientFormViewModel
                {
                   patient = patient,
                   Detection = _spec.GetRecords

                };

                return View("PatientForm", viewModel);
            }

            if (patient._Id == Guid.Empty)
                _context.InsertRecord(_table, patient);

            else
            {
                var patientInDb = _context.LoadRecordByIdProperity<Patient>(_table, patient.Id);
                patientInDb.Address = patient.Address;
                patientInDb.Email = patient.Email;
                patientInDb.BloodType = patient.BloodType;
                patientInDb.Name = patient.Name;
                patientInDb.Age = patient.Age;
                patientInDb.Id = patient.Id;
                patientInDb.Phone = patient.Phone;
                patientInDb.DetectionId = patient.DetectionId;
                patientInDb.Notes = patient.Notes;

                _context.UPsertRecordByObjectId(_table, patient._Id, patient);
            }

            return RedirectToAction("Index", "Patients");
        }

        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
            var patients = _context.LoadRecords<Patient>(_table);
            return View(patients);
        }
    }
}