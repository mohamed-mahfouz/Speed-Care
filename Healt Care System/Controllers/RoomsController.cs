using System;
using System.Web.Mvc;
using Healt_Care_System.Entities;
using Healt_Care_System.Models;
using Healt_Care_System.ViewModel;
using MongoDB.Bson;

namespace Healt_Care_System.Controllers
{
    public class RoomsController : Controller
    {

        private MongoDBContext _context;
        private string _table;
        private PopulateRoomTypes _roomTypes;

        public RoomsController()
        {
            _context = new MongoDBContext();
            _roomTypes = new PopulateRoomTypes();
            _table = "Rooms";
        }

        public ActionResult GetData()
        {
            var rooms = _context.LoadRecords<Room>(_table);
            return Json(new { data = rooms }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(string id)
        {

            _context.DeleteRecordByIdProperity<Room>(_table, id);

            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var room = new Room();
            room.RoomId = GenerateUniqueID();

            var viewModel = new RoomFormViewModel
            {
                Room = room,
                RoomTypes = _roomTypes.GetRecords
            };

            return View("RoomForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var room = _context.LoadRecordByIdProperity<Room>(_table, id);

            if (room == null)
                return HttpNotFound();

            var viewModel = new RoomFormViewModel
            {

                Room = room,
                RoomTypes = _roomTypes.GetRecords
                          
            };

            return View("RoomForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Room room)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RoomFormViewModel
                {
                    Room = room,
                    RoomTypes = _roomTypes.GetRecords

                };

                return View("RoomForm", viewModel);
            }

            if (room.Id == Guid.Empty)
                _context.InsertRecord(_table, room);

            else
            {
                var roomInDb = _context.LoadRecordByIdProperity<Room>(_table, room.RoomId);

                roomInDb.RoomId = room.RoomId;               
                roomInDb.RoomTypeId = room.RoomTypeId;
                roomInDb.Floor = room.Floor;
                _context.UPsertRecordByObjectId(_table, room.Id, room);

            }

            return RedirectToAction("Index", "Rooms");
        }


        private string GenerateUniqueID()
        {

            var randomId = ObjectId.GenerateNewId().ToString();
            var id = randomId.Substring(19);

            return id;
        }

        public ActionResult Index()
        {
            var rooms = _context.LoadRecords<Room>(_table);
            return View(rooms);
        }
    }
}