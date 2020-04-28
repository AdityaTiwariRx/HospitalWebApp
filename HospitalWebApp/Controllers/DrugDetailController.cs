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
    public class DrugDetailController:ControllerBase
    {
        public DrugDetailDomain drugDetailDomain { get; set; }
        public DrugDetailController()
        {
            this.drugDetailDomain = new DrugDetailDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.drugDetailDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(DrugDetails drugDetail)
        {
            drugDetailDomain.Add(drugDetail);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(DrugDetails drugDetail)
        {
            drugDetailDomain.Update(drugDetail);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            drugDetailDomain.Delete(id);
            return Ok();
        }
    }
}
