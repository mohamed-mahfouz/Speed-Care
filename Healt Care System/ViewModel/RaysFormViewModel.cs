using System.Collections.Generic;
using Healt_Care_System.Models;

namespace Healt_Care_System.ViewModel
{
    public class RaysFormViewModel
    {

        public Rays Rays { get; set; }
        public IEnumerable<RaysType> RaysType { get; set; }
        public IEnumerable<RaysArea> RaysArea { get; set; }

    }
}