using Healt_Care_System.Entities;
using Healt_Care_System.Entities.MedicalTests;
using Healt_Care_System.Models.MedicalTests;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Healt_Care_System.Controllers
{
    public class TestsController : Controller
    {
        private MongoDBContext _context;
        private PopulateMedicalTest _medicalTest;
        private PopulateMedicalType _medicalType;
        private string table;

        public TestsController()
        {
            _context = new MongoDBContext();
            _medicalTest = new PopulateMedicalTest();
            _medicalType = new PopulateMedicalType();
            table = "Tests";
        }

        // loading Table records as Json Format 
        public ActionResult GetData()
        {
            var tests = _context.LoadRecords<Tests>(table);
            return Json(new { data = tests }, JsonRequestBehavior.AllowGet);
        }

        // Populating MedicalType in Ajax
        public ActionResult GetTypeData(int Id)
        {
            var medicalType = (List<MedicalType>)_context.LoadRecords<MedicalType>("MedicalType");
            var newMedicalType = new List<MedicalType>();

            for (int i = 0; i < medicalType.Count; i++)
            {
                if (medicalType[i].MedicalTestId == Id)
                    newMedicalType.Add(medicalType[i]);
            }

            return Json(newMedicalType, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            _context.DeleteRecordByIdProperity<Tests>(table, id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var tests = new Tests();
            tests.Id = GenerateUniqueId();

            var viewModel = new TestsViewModel
            {
                Tests = tests,
                MedicalTest = _medicalTest.GetRecords,
            };
            return View("TestForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Tests tests)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TestsViewModel
                {
                    Tests = tests,
                    MedicalTest = _medicalTest.GetRecords,
                };
                return View("TestForm", viewModel);
            }

            if (tests._Id == Guid.Empty)
                _context.InsertRecord(table, tests);
            else
                return HttpNotFound();
            
            return RedirectToAction("Index", "Tests");
        }

        private string GenerateUniqueId()
        {
            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }



        // GET: Tests
        public ActionResult Index()
        {
            var tests = _context.LoadRecords<Tests>(table);
            
            return View(tests);
        }
    }
}