using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalWebApp.Domain;
using HospitalWebApp.Models;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController: ControllerBase
    {
        public PatientDomain patientDomain { get; set; }
        public PatientController()
        {
            this.patientDomain = new PatientDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.patientDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Patient patient)
        {
            patientDomain.Add(patient);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Patient patient)
        {
            patientDomain.Update(patient);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            patientDomain.Delete(id);
            return Ok();
        }

    }
}
