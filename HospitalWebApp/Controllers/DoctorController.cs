using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalWebApp.Domain;
using HospitalWebApp.Models;

namespace HospitalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController:ControllerBase
    {
        public DoctorDomain doctorDomain { get; set; }
        public DoctorController()
        {
            this.doctorDomain = new DoctorDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.doctorDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Doctor doctor)
        {
            doctorDomain.Add(doctor);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Doctor doctor)
        {
            doctorDomain.Update(doctor);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            doctorDomain.Delete(id);
            return Ok();
        }
    }
}
