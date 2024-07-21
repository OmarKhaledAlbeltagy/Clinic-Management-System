using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Models;
using ClinicSystem.Privilage;
using ClinicSystem.Repo;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRep rep;
        private readonly UserManager<ExtendIdentityUser> userManager;
        private readonly SignInManager<ExtendIdentityUser> signInManager;

        public UserController(IUserRep rep, UserManager<ExtendIdentityUser> userManager, SignInManager<ExtendIdentityUser> signInManager)
        {
            this.rep = rep;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult IsAssistantExist()
        {
            return Ok(rep.IsAssistantExist());
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditPassword([FromBody] EditPasswordModel obj)
        {
            return Ok(rep.EditPassword(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditEmail([FromBody] EditEmailModel obj)
        {
            return Ok(rep.EditEmail(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditUserGeneralSetting([FromBody] UserGeneralSettingModel obj)
        {
            return Ok(rep.EditUserGeneralSetting(obj));
        }


        [Route("[controller]/[Action]/{id?}")]
        [HttpGet]
        public IActionResult GetUserById(string id)
        {
            return Ok(rep.GetUserById(id));
        }

        [Route("[controller]/[Action]/{email?}")]
        [HttpGet]
        public IActionResult CheckEmailExist(string email)
        {
            return Ok(rep.CheckEmailExist(email));
        }

        [Route("[controller]/[Action]/{phone?}")]
        [HttpGet]
        public IActionResult CheckPhoneExist(string phone)
        {
            return Ok(rep.CheckPhoneExist(phone));
        }


        [Route("[controller]/[Action]/{email}")]
        [HttpGet]
        public IActionResult ResendEmailConfirmation(string email)
        {
            return Ok(rep.ResendEmailConfirmation(email));
        }


        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult RegisterDoctor([FromBody] DoctorRegisterModel obj)
        {
            return Ok(rep.RegisterDoctor(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult RegisterAssistant([FromBody] AssistantRegisterModel obj)
        {
            return Ok(rep.RegisterAssistant(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult ActivateEmail([FromBody] ConfirmEmailModel obj)
        {
            return Ok(rep.ActivateEmail(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult ActivateEmailAndConfirmSetup([FromBody] ConfirmEmailModel obj)
        {
            return Ok(rep.ActivateEmailAndConfirmSetup(obj));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel obj)
        {
            ExtendIdentityUser usercheck = userManager.FindByEmailAsync(obj.Email).Result;
            if (usercheck == null)
            {
                return Ok("not found");
            }
            else
            {
                if (usercheck.Active == false)
                {
                    return Ok("deactivated");
                }
                else
                {
                    var res = signInManager.PasswordSignInAsync(obj.Email, obj.Password, false, false).Result;

                    if (res.IsNotAllowed)
                    {
                        return Ok("not allowed");
                    }
                    else
                    {
                        if (res.Succeeded)
                        {
                            ExtendIdentityUser user = userManager.FindByEmailAsync(obj.Email).Result;
                            string role = userManager.GetRolesAsync(user).Result.FirstOrDefault();
                            SignInModel userrole = new SignInModel();
                            userrole.FirstName = user.FirstName;
                            userrole.MiddleName = user.MiddleName;
                            userrole.LastName = user.LastName;
                            userrole.Email = user.Email;
                            userrole.UserId = user.Id;
                            userrole.RoleName = role;
                            return Ok(userrole);
                        }
                        else
                        {
                            return Ok("wrong password");
                        }
                    }
                }
            }


        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult LogOut()
        {
            Task x = signInManager.SignOutAsync();

            if (x.IsCompletedSuccessfully)
            {
                return Ok(true);
            }

            else
            {
                return BadRequest(x.Exception.Message);
            }

        }
    }
}
