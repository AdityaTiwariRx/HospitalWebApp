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
    public class AssistantController:ControllerBase
    {
        public AssistantDomain assistantDomain { get; set; }
        public AssistantController()
        {
            this.assistantDomain = new AssistantDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.assistantDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Assistant assistant)
        {
            assistantDomain.Add(assistant);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Assistant assistant)
        {
            assistantDomain.Update(assistant);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            assistantDomain.Delete(id);
            return Ok();
        }


    }
}
