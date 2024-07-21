using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Context;
using ClinicSystem.Entities;
using ClinicSystem.Privilage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ClinicSystem.Controllers
{
    [EnableCors("allow")]
    [ApiController]
    [AllowAnonymous]
    public class DevController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DbContainer db;

        public DevController(RoleManager<IdentityRole> roleManager, DbContainer db)
        {
            this.roleManager = roleManager;
            this.db = db;
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult week()
        {
            DateTime now = DateTime.Now;
            DateTime tom = DateTime.Now.AddDays(1);
            TimeSpan res = tom - now;

            return Ok(res);

        }


        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult ResetInsuranceOperations()
        {
            IEnumerable<InsurancePackageOperation> list = db.insurancePackageOperation.Select(a => a);
            foreach (var item in list)
            {
                db.insurancePackageOperation.Remove(item);
            }
            IEnumerable<int> OperationsIds = db.operation.Select(a => a.Id);
            IEnumerable<int> PackagesIds = db.insurancePackage.Select(a => a.Id);

            foreach (var o in OperationsIds)
            {
                foreach (var p in PackagesIds)
                {
                    InsurancePackageOperation obj = new InsurancePackageOperation();
                    obj.InsurancePackageId = p;
                    obj.OperationId = o;
                    obj.PaidByPatient = db.operation.Find(o).Price;
                    obj.PaidByInsurance = 0;
                    obj.TotalPrice = db.operation.Find(o).Price;
                    db.insurancePackageOperation.Add(obj);
                }
            }
            db.SaveChanges();

            return Ok(true);
           
        }




        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult Reset()
        {
            IEnumerable<WorkingTime> WT = db.workingTime.Select(a => a);
            IEnumerable<AppointmentType> appointmettype = db.appointmentType.Select(a => a);

            IEnumerable<DoctorProcessPrice> DPP = db.doctorProcessPrice.Select(a => a);

            IEnumerable<IdentityUserRole<string>> UserRoles = db.UserRoles.Select(a => a);

            IEnumerable<ExtendIdentityUser> Users = db.Users.Select(a => a);

            IEnumerable<IdentityRole> roles = db.Roles.Select(a => a);

            IEnumerable<Gender> genders = db.gender.Select(a => a);

            IEnumerable<InsurancePackageOperation> InsurancePackageOperation = db.insurancePackageOperation.Select(a => a);

            IEnumerable<InsurancePackage> InsurancePackage = db.insurancePackage.Select(a => a);

            IEnumerable<Insurance> Insurance = db.insurance.Select(a => a);

            IEnumerable<Operation> operation = db.operation.Select(a => a);

            IEnumerable<ProcessType> PT = db.processType.Select(a => a);

            foreach (var item in WT)
            {
                db.workingTime.Remove(item);
            }
            foreach (var item in DPP)
            {
                db.doctorProcessPrice.Remove(item);
            }
            foreach (var item in appointmettype)
            {
                db.appointmentType.Remove(item);
            }
            foreach (var item in UserRoles)
            {
                db.UserRoles.Remove(item);
            }
            db.SaveChanges();

            foreach (var item in Users)
            {
                db.Users.Remove(item);
            }
            foreach (var item in roles)
            {
                db.Roles.Remove(item);
            }
            foreach (var item in genders)
            {
                db.gender.Remove(item);
            }
            foreach (var item in InsurancePackageOperation)
            {
                db.insurancePackageOperation.Remove(item);
            }
            db.SaveChanges();
            foreach (var item in InsurancePackage)
            {
                db.insurancePackage.Remove(item);
            }
            db.SaveChanges();
            foreach (var item in Insurance)
            {
                db.insurance.Remove(item);
            }
            foreach (var item in operation)
            {
                db.operation.Remove(item);
            }
            foreach (var item in PT)
            {
                db.processType.Remove(item);
            }
            Setup set = db.setup.FirstOrDefault();
            set.IsSetup = false;
            db.SaveChanges();
            
            return Ok(true);
        }



        [Route("[controller]/[Action]/{roleName}")]
        [HttpGet]
        public IActionResult AddRole(string roleName)
        {
            IdentityRole r = new IdentityRole();
            r.Name = roleName;
            IdentityResult x = roleManager.CreateAsync(r).Result;

            if (x.Succeeded)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
