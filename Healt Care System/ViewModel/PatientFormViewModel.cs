using Healt_Care_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healt_Care_System.ViewModel
{
    public class PatientFormViewModel
    {

        public Patient patient { get; set; }
        public IEnumerable<specilization> Detection { get; set; }

    }
}