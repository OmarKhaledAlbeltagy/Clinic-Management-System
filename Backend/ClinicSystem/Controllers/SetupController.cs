using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using ClinicSystem.Repo;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    [EnableCors("allow")]
    [ApiController]
    [AllowAnonymous]
    public class SetupController : ControllerBase
    {
        private readonly ISetupRep rep;

        public SetupController(ISetupRep rep)
        {
            this.rep = rep;
        }


  
        [Route("[controller]/[Action]/{PackageId}/{OperationId}")]
        [HttpGet]
        public IActionResult GetSuggestedOperationPricing(int PackageId, int OperationId)
        {
            return Ok(rep.GetSuggestedOperationPricing(PackageId,OperationId));
        }


        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult CheckPricing(string id)
        {
            return Ok(rep.CheckPricing(id));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetOperationsCount()
        {
            return Ok(rep.GetOperationsCount());
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupInsurancePackagesOperation([FromBody] List<InsurancePackageOperation> list)
        {
            return Ok(rep.SetupInsurancePackagesOperation(list));
        }


        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupInsurances([FromBody] List<Insurance> list)
        {
            return Ok(rep.SetupInsurances(list));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult ConfirmSetup()
        {
            return Ok(rep.ConfirmSetup());
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult omar()
        {
            string res = "";
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\EmailTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            res = str.ReadToEnd();
            str.Close();
            return Ok(res);
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult CheckSetupStatus()
        {
            return Ok(rep.CheckSetupStatus());
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupAppointmentTypes([FromBody] List<AppointmentType> list)
        {
            return Ok(rep.SetupAppointmentTypes(list));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupGenders([FromBody] List<Gender> list)
        {
            return Ok(rep.SetupGenders(list));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupOperations([FromBody] List<Operation> list)
        {
            return Ok(rep.SetupOperations(list));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult SetupInsurancePackages([FromBody] List<InsurancePackageModel> list)
        {
            return Ok(rep.SetupInsurancePackages(list));
        }

    }
}
