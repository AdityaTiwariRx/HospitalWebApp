using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class Assistant
    {

        public int AssistantId { get; set; }
        public string AssistantName { get; set; }
        public string AssistantGender { get; set; }
        public int AssistantAge { get; set; }
        public int DepartmentId { get; set; }
    }
}
