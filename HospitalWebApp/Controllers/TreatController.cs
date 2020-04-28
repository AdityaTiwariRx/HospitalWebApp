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
    public class TreatController: ControllerBase
    {
        public TreatDomain treatDomain { get; set; }
        public TreatController()
        {
            this.treatDomain = new TreatDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.treatDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Treat treat)
        {
            treatDomain.Add(treat);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Treat treat)
        {
            treatDomain.Update(treat);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            treatDomain.Delete(id);
            return Ok();
        }

    }
}
