using System.Collections.Generic;
using Healt_Care_System.Models;

namespace Healt_Care_System.ViewModel
{
    public class RoomFormViewModel
    {
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public Room Room { get; set; }


    }
}