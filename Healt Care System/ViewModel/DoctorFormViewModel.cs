using System.Collections.Generic;
using Healt_Care_System.Models;

namespace Healt_Care_System.ViewModel
{
    public class DoctorFormViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<specilization> specs { get; set; }
        public IEnumerable<DoctorDegree> Degree { get; set; }

    }
}