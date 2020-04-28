using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class Treat
    {

        public int TreatmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }


    }
}
