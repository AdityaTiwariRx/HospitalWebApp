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
    public class AppointmentController:ControllerBase
    {
        public AppointmentDomain appointmentDomain { get; set; }
        public AppointmentController()
        {
            this.appointmentDomain = new AppointmentDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.appointmentDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Appointment appointment)
        {
            appointmentDomain.Add(appointment);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Appointment appointment)
        {
            appointmentDomain.Update(appointment);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            appointmentDomain.Delete(id);
            return Ok();
        }


    }
}





 
