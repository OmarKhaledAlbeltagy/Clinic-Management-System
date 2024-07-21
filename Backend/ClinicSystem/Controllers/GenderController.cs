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
    public class GenderController : ControllerBase
    {
        private readonly IGenderRep rep;

        public GenderController(IGenderRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddGender([FromBody] Gender obj)
        {
            return Ok(rep.AddGender(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditGender([FromBody] Gender obj)
        {
            return Ok(rep.EditGender(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteGender(int id)
        {
            return Ok(rep.DeleteGender(id));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllGenders()
        {
            return Ok(rep.GetAllGenders());
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetGenderById(int id)
        {
            return Ok(rep.GetGenderById(id));
        }
    }
}
