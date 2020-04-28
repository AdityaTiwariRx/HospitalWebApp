using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApp.Domain;
using HospitalWebApp.Models;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDrugDetailController:ControllerBase
    {
        public PatientDrugDetailDomain patientDrugDetailDomain { get; set; }
        public PatientDrugDetailController()
        {
            this.patientDrugDetailDomain = new PatientDrugDetailDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.patientDrugDetailDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(PatientDrugDetails patientDrugDetail)
        {
            patientDrugDetailDomain.Add(patientDrugDetail);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(PatientDrugDetails patientDrugDetail)
        {
            patientDrugDetailDomain.Update(patientDrugDetail);
            return Ok();
        }
        
        

    }
}
