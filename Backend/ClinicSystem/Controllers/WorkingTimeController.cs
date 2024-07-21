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
    public class WorkingTimeController : ControllerBase
    {
        private readonly IWorkingTimeRep rep;

        public WorkingTimeController(IWorkingTimeRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditWorkingTime(WorkingTime obj)
        {
            return Ok(rep.EditWorkingTime(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteWorkingTime(int id)
        {
            return Ok(rep.DeleteWorkingTime(id));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddDoctorWorkingTime(WorkingTime obj)
        {
            return Ok(rep.AddDoctorWorkingTime(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetDoctorWorkingDays(string id)
        {
            return Ok(rep.GetDoctorWorkingDays(id));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult CheckDoctorWorkingTime(string id)
        {
            return Ok(rep.CheckDoctorWorkingTime(id));
        }
    }
}
