using System;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;

namespace Healt_Care_System.Controllers
{
    public class PharmacyController : Controller
    {
        private MongoDBContext _context;
     
        private string _table;

        public PharmacyController()
        {

            _context = new MongoDBContext();
            _table = "pharmacy";

        }

        public ActionResult GetData()
        {
            var nurses = _context.LoadRecords<pharmacy>(_table);
            return Json(new { data = nurses }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var drug = new pharmacy();
            drug.Id = GenerateUniqueID();

            var viewModel = new PharmacyFormViewModel
            {
                Pharmacy = drug

            };

            return View("PharmacyForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var drug = _context.LoadRecordByIdProperity<pharmacy>(_table, id);

            if (drug == null)
                return HttpNotFound();
            var viewModel = new PharmacyFormViewModel
            {

                Pharmacy = drug

            };

            return View("PharmacyForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(pharmacy invoice)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PharmacyFormViewModel
                {
                    Pharmacy = invoice
                };

                return View("PharmacyForm", viewModel);
            }

            if (invoice._Id == Guid.Empty)
                _context.InsertRecord(_table, invoice);

            else
            {
                var invoiceInDb = _context.LoadRecordByIdProperity<pharmacy>(_table, invoice.Id);
                invoiceInDb.Patient = invoice.Patient;
                invoiceInDb.Notes = invoice.Notes;
                invoiceInDb.Price = invoice.Price;
                invoiceInDb.Drugs = invoice.Drugs;

                _context.UPsertRecordByObjectId(_table, invoice._Id, invoice);

            }

            return RedirectToAction("Index", "Pharmacy");
        }

        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
            var drugs = _context.LoadRecords<pharmacy>(_table);
            return View(drugs);
        }
        //private MongoDBContext _context;
        //private PopulateDrugTypes _drugType;
        //private string _table;

        //public PharmacyController()
        //{

        //    _context = new MongoDBContext();
        //    _drugType = new PopulateDrugTypes();
        //    _table = "Drugs";

        //}

        //public ActionResult GetData()
        //{
        //    var nurses = _context.LoadRecords<Drug>(_table);
        //    return Json(new { data = nurses }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult New()
        //{
        //    var drug = new Drug();
        //    drug.DrugId = GenerateUniqueID();

        //    var viewModel = new DrugFormViewModel
        //    {
        //        Drug = drug,
        //        DrugTypes = _drugType.GetRecords

        //    };

        //    return View("PharmacyForm", viewModel);
        //}

        //public ActionResult Edit(string id)
        //{
        //    var drug = _context.LoadRecordByIdProperity<Drug>(_table, id);

        //    if (drug == null)
        //        return HttpNotFound();
        //    var viewModel = new DrugFormViewModel
        //    {

        //        Drug=drug,
        //        DrugTypes=_drugType.GetRecords

        //    };

        //    return View("PharmacyForm", viewModel);
        //}

        //[HttpPost]
        //public ActionResult Save(Drug drug)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new DrugFormViewModel
        //        {
        //            Drug=drug,
        //            DrugTypes=_drugType.GetRecords

        //        };

        //        return View("PharmacyForm", viewModel);
        //    }

        //    if (drug.Id == Guid.Empty)
        //        _context.InsertRecord(_table, drug);

        //    else
        //    {
        //        var drugInDb = _context.LoadRecordByIdProperity<Drug>(_table, drug.DrugId);
        //        drugInDb.DrugTypeId = drug.DrugTypeId;
        //        drugInDb.Concentration = drug.Concentration;
        //        drugInDb.Name = drug.Name;
        //        drugInDb.Price = drug.Price;
        //        drugInDb.Quantity = drug.Quantity;

        //        _context.UPsertRecordByObjectId(_table, drug.Id, drug);

        //    }

        //    return RedirectToAction("Index", "Pharmacy");
        //}

        //private string GenerateUniqueID()
        //{

        //    var randomId = ObjectId.GenerateNewId().ToString();
        //    var id = randomId.Substring(19);

        //    return id;
        //}

        //public ActionResult Index()
        //{
        //    var drugs = _context.LoadRecords<Drug>(_table);
        //    return View(drugs);
        //}
    }
}