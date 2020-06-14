using System;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Healt_Care_System.Controllers
{
    public class RaysController : Controller
    {

        MongoDBContext _context;
        PopulateRaysTypes _raysTypes;
        PopulateRaysAreas _raysAreas;
        string _table;

        public RaysController()
        {
            _context = new MongoDBContext();
            _raysTypes = new PopulateRaysTypes();
            _raysAreas = new PopulateRaysAreas();
            _table = "Rays";

        }

        public ActionResult GetData()
        {
            var rays = _context.LoadRecords<Rays>(_table);
            return Json(new { data = rays }, JsonRequestBehavior.AllowGet);
        }

        //Populating RaysAreas in Ajax Request.
        public ActionResult GetAreasData(int TypeId)
        {
            var rays = (List<RaysArea>)_context.LoadRecords<RaysArea>("RaysAreas");
            var targetRaysType = new List<RaysArea>();

            for (int i = 0; i < rays.Count; ++i)
            {

                if (rays[i].RaysTypeId == TypeId)
                    targetRaysType.Add(rays[i]);

            }

            return Json(targetRaysType, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {

            _context.DeleteRecordByIdProperity<Rays>(_table, id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var rays = new Rays();
            rays.Id = GenerateUniqueID();

            var viewModel = new RaysFormViewModel
            {
                Rays = rays,
                RaysType = _raysTypes.GetRecords,
                
                
            };

            return View("RaysForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Rays rays)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RaysFormViewModel
                {
                    Rays = rays,                   
                    RaysType = _raysTypes.GetRecords,
                   
                   
                };

                return View("RaysForm", viewModel);
            }

            if (rays._Id == Guid.Empty)
                _context.InsertRecord(_table, rays);

            else
                return HttpNotFound();           

            return RedirectToAction("Index", "Rays");
        }

        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
            var rays = _context.LoadRecords<Rays>(_table);

            return View(rays);
        }
    }
}