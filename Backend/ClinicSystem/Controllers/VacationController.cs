using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Repo;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    [EnableCors("allow")]
    [ApiController]
    [AllowAnonymous]
    public class VacationController : ControllerBase
    {
        private readonly IVacationRep rep;

        public VacationController(IVacationRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult IsFullDayVacancy([FromBody] DoctorAvailabeTimeModel obj)
        {
            return Ok(rep.IsFullDayVacancy(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteVacation(int id)
        {
            return Ok(rep.DeleteVacation(id));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult CreateVacation([FromBody] DoctorVacationModel obj)
        {
            return Ok(rep.CreateVacation(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetDoctorVacations(string id)
        {
            return Ok(rep.GetDoctorVacations(id));
        }
    }
}
