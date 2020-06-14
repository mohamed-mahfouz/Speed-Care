using System.Collections.Generic;
using Healt_Care_System.Models;

namespace Healt_Care_System.ViewModel
{
    public class DrugFormViewModel
    {
        public Drug Drug { get; set; }
        public IEnumerable<DrugType> DrugTypes { get; set; }


    }
}