using System.Collections.Generic;
using Healt_Care_System.Models;

namespace Healt_Care_System.ViewModel
{
    public class NurseFormViewModel
    {
        public Nurse Nurse { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<NurseDegree> Degree { get; set; }
    }
}