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
    public class ProcessTypeController : ControllerBase
    {
        private readonly IProcessTypeRep rep;

        public ProcessTypeController(IProcessTypeRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditProcessPricing(IEnumerable<EditPricingModel> list)
        {
            return Ok(rep.EditProcessPricing(list));
        }


        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetMyProcessPricing(string id)
        {
            return Ok(rep.GetMyProcessPricing(id));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllProcesses()
        {
            return Ok(rep.GetAllProcesses());
        }
    }
}
