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
    public class DepartmentController : ControllerBase
    {
        public DepartmentDomain departmentDomain { get; set; }
        public DepartmentController()
        {
            this.departmentDomain = new DepartmentDomain();
        }
        [HttpGet]
        public IActionResult Get()
        {

            var m = this.departmentDomain.Get();
            return Ok(m);

        }
        [HttpPost]
        public IActionResult Post(Department department)
        {
            departmentDomain.Add(department);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Department department)
        {
            departmentDomain.Update(department);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            departmentDomain.Delete(id);
            return Ok();
        }
    }
}