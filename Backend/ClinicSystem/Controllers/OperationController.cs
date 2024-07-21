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
    public class OperationController : ControllerBase
    {
        private readonly IOperationRep rep;

        public OperationController(IOperationRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddOperation([FromBody] Operation obj)
        {
            return Ok(rep.AddOperation(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditOperation([FromBody] Operation obj)
        {
            return Ok(rep.EditOperation(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteOperation(int id)
        {
            return Ok(rep.DeleteOperation(id));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpPost]
        public IActionResult GetOperationById(int id)
        {
            return Ok(rep.GetOperationById(id));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllOperations()
        {
            return Ok(rep.GetAllOperations());
        }
    }
}
