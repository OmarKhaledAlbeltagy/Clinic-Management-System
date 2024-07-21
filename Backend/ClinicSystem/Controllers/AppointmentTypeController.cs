using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Entities;
using ClinicSystem.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    [EnableCors("allow")]
    [ApiController]
    [AllowAnonymous]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly IAppointmentTypeRep rep;

        public AppointmentTypeController(IAppointmentTypeRep rep) 
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddAppointmentType([FromBody] AppointmentType obj)
        {
            return Ok(rep.AddAppointmentType(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditAppointmentType([FromBody] AppointmentType obj)
        {
            return Ok(rep.EditAppointmentType(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteAppointmentType(int id)
        {
            return Ok(rep.DeleteAppointmentType(id));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllAppointmentTypes()
        {
            return Ok(rep.GetAllAppointmentTypes());
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetAppointmentTypeById(int id)
        {
            return Ok(rep.GetAppointmentTypeById(id));
        }
    }
}
