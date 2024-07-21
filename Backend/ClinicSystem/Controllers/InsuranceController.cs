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
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceRep rep;

        public InsuranceController(IInsuranceRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditPlanOperationsPricing([FromBody] IEnumerable<InsurancePackageOperation> list)
        {
            return Ok(rep.EditPlanOperationsPricing(list));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetOperationPackageByPackageId(int id)
        {
            return Ok(rep.GetOperationPackageByPackageId(id));
        }


        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditPlanExaminationPricing([FromBody] InsurancePackage obj)
        {
            return Ok(rep.EditPlanExaminationPricing(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditPlanFollowupPricing([FromBody] InsurancePackage obj)
        {
            return Ok(rep.EditPlanFollowupPricing(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeletePackage(int id)
        {
            return Ok(rep.DeletePackage(id));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditPackageName([FromBody] InsurancePackage obj)
        {
            return Ok(rep.EditPackageName(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddInsurancePackage([FromBody] InsurancePackage obj)
        {
            return Ok(rep.AddInsurancePackage(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteInsurance(int id)
        {
            return Ok(rep.DeleteInsurance(id));
        }


        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult AddInsurance([FromBody] Insurance obj)
        {
            return Ok(rep.AddInsurance(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditInsurance([FromBody] Insurance obj)
        {
            return Ok(rep.EditInsurance(obj));
        }



        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllInsurances()
        {
            return Ok(rep.GetAllInsurances());
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAllInsurancesPackages()
        {
            return Ok(rep.GetAllInsurancesPackages());
        }
    }
}
