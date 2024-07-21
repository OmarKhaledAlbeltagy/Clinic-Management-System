using ClinicSystem.Context;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using ClinicSystem.Privilage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class UserRep : IUserRep
    {
        private readonly UserManager<ExtendIdentityUser> userManager;
        private readonly ISetupRep setup;
        private readonly DbContainer db;

        public UserRep(UserManager<ExtendIdentityUser> userManager, ISetupRep setup, DbContainer db)
        {
            this.userManager = userManager;
            this.setup = setup;
            this.db = db;
        }

        private static Random random = new Random();

        public bool ActivateEmail(ConfirmEmailModel obj)
        {
            ExtendIdentityUser user = userManager.FindByEmailAsync(obj.Email).Result;
            IdentityResult res = userManager.ConfirmEmailAsync(user, obj.token).Result;

            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActivateEmailAndConfirmSetup(ConfirmEmailModel obj)
        {
            ExtendIdentityUser user = userManager.FindByEmailAsync(obj.Email).Result;
            IdentityResult res = userManager.ConfirmEmailAsync(user, obj.token).Result;

            if (res.Succeeded)
            {
                setup.ConfirmSetup();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmailExist(string mail)
        {
            List<string> emails = userManager.Users.Select(a => a.Email).ToList();

            foreach (var item in emails)
            {
                if(item == mail)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckPhoneExist(string phone)
        {
            List<string> phones = userManager.Users.Select(a => a.PhoneNumber).ToList();

            foreach (var item in phones)
            {
                if (item == phone)
                {
                    return true;
                }
            }

            return false;
        }


        public bool RegisterDoctor(DoctorRegisterModel obj)
        {
            ExtendIdentityUser u = new ExtendIdentityUser();
            u.Email = obj.Email;
            u.UserName = obj.Email;
            u.FirstName = obj.FirstName;
            u.MiddleName = obj.MiddleName;
            u.LastName = obj.LastName;
            u.PhoneNumber = obj.PhoneNumber;
            u.ExaminationTime = obj.ExaminationTime;
            u.SecurityStamp = Guid.NewGuid().ToString();
            var result = userManager.CreateAsync(u, obj.Password).Result;
            var addtorole = userManager.AddToRoleAsync(u, obj.RoleName).Result;

            if (result.Succeeded)
            {
                
                ExtendIdentityUser user = userManager.FindByEmailAsync(obj.Email).Result;
                IEnumerable<ProcessType> processes = db.processType.Select(a => a);
                foreach(var item in processes)
                {
                    DoctorProcessPrice DPP = new DoctorProcessPrice();
                    DPP.extendidentityuserid = user.Id;
                    DPP.processtypeid = item.Id;
                    DPP.Price = 0;
                    db.doctorProcessPrice.Add(DPP);
                }
                db.SaveChanges();

                string token = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                string body = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js\" integrity=\"sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js\" integrity=\"sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13\" crossorigin=\"anonymous\"></script>\r\n\r\n    <title>Activate account</title>\r\n</head>\r\n<body>\r\n\r\n\r\n\r\n    <div align=\"center\">\r\n\r\n        <h1>Hi, Dr. [Name]</h1>\r\n        <h3>You are almost done, simply click below button to activate your account</h3>\r\n\r\n\r\n        <br><br>\r\n        <a href=\"[Domain]emailconfirmed.html?[Token]&[Email]\" role=\"button\" class=\"btn btn-success btn-lg\">Activate</a>\r\n    </div>\r\n\r\n\r\n\r\n  \r\n\r\n</body>\r\n</html>";

                body = body.Replace("[Name]", obj.FirstName+" "+obj.MiddleName).Replace("[Domain]", EmailModel.Domain).Replace("[Token]", token).Replace("[Email]",obj.Email);
                
                MailMessage m = new MailMessage();
                m.To.Add(obj.Email);
                m.Subject = obj.FirstName+" "+obj.MiddleName+" Clinic System Email Confirmation";
                m.From = new MailAddress(EmailModel.EmailAddress);
                m.Sender = new MailAddress(EmailModel.EmailAddress);
                m.Body = body;
               // m.IsBodyHtml = true;
                m.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient(EmailModel.SmtpServer, EmailModel.port);
                smtp.EnableSsl = false;
                smtp.Credentials = new NetworkCredential(EmailModel.EmailAddress, EmailModel.Password);
                smtp.Send(m);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResendEmailConfirmation(string email)
        {
            ExtendIdentityUser user = userManager.FindByEmailAsync(email).Result;
            if (user == null)
            {
                return false;
            }

            else
            {
                string token = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                string body = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js\" integrity=\"sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js\" integrity=\"sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13\" crossorigin=\"anonymous\"></script>\r\n\r\n    <title>Activate account</title>\r\n</head>\r\n<body>\r\n\r\n\r\n\r\n    <div align=\"center\">\r\n\r\n        <h1>Hi, Dr. [Name]</h1>\r\n        <h3>You are almost done, simply click below button to activate your account</h3>\r\n\r\n\r\n        <br><br>\r\n        <a href=\"[Domain]emailconfirmed.html?[Token]&[Email]\" role=\"button\" class=\"btn btn-success btn-lg\">Activate</a>\r\n    </div>\r\n\r\n\r\n\r\n  \r\n\r\n</body>\r\n</html>";

                body = body.Replace("[Name]", user.FirstName + " " + user.MiddleName).Replace("[Domain]", EmailModel.Domain).Replace("[Token]", token).Replace("[Email]", user.Email);

                MailMessage m = new MailMessage();
                m.To.Add(user.Email);
                m.Subject = user.FirstName + " " + user.MiddleName + " Clinic System Email Confirmation";
                m.From = new MailAddress(EmailModel.EmailAddress);
                m.Sender = new MailAddress(EmailModel.EmailAddress);
                m.Body = body;
                m.IsBodyHtml = true;
                m.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient(EmailModel.SmtpServer, EmailModel.port);
                smtp.EnableSsl = false;
                smtp.Credentials = new NetworkCredential(EmailModel.EmailAddress, EmailModel.Password);
                smtp.Send(m);

                return true;
            }
        }

        public bool RegisterAssistant(AssistantRegisterModel obj)
        {
            ExtendIdentityUser u = new ExtendIdentityUser();
            u.Email = obj.Email;
            u.UserName = obj.Email;
            u.FirstName = obj.FirstName;
            u.MiddleName = obj.MiddleName;
            u.LastName = obj.LastName;
            u.PhoneNumber = obj.PhoneNumber;
            u.SecurityStamp = Guid.NewGuid().ToString();
            var result = userManager.CreateAsync(u, obj.Password).Result;
            var addtorole = userManager.AddToRoleAsync(u, obj.RoleName).Result;

            if (result.Succeeded)
            {
                ExtendIdentityUser user = userManager.FindByEmailAsync(obj.Email).Result;
                string token = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                string body = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js\" integrity=\"sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB\" crossorigin=\"anonymous\"></script>\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js\" integrity=\"sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13\" crossorigin=\"anonymous\"></script>\r\n\r\n    <title>Activate account</title>\r\n</head>\r\n<body>\r\n\r\n\r\n\r\n    <div align=\"center\">\r\n\r\n        <h1>Hi, Dr. [Name]</h1>\r\n        <h3>You are almost done, simply click below button to activate your account</h3>\r\n\r\n\r\n        <br><br>\r\n        <a href=\"[Domain]emailconfirmed.html?[Token]&[Email]\" role=\"button\" class=\"btn btn-success btn-lg\">Activate</a>\r\n    </div>\r\n\r\n\r\n\r\n  \r\n\r\n</body>\r\n</html>";

                body = body.Replace("[Name]", obj.FirstName + " " + obj.MiddleName).Replace("[Domain]", EmailModel.Domain).Replace("[Token]", token).Replace("[Email]", obj.Email);

                MailMessage m = new MailMessage();
                m.To.Add(obj.Email);
                m.Subject = obj.FirstName + " " + obj.MiddleName + " Clinic System Email Confirmation";
                m.From = new MailAddress(EmailModel.EmailAddress);
                m.Sender = new MailAddress(EmailModel.EmailAddress);
                m.Body = body;
                m.IsBodyHtml = true;
                m.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient(EmailModel.SmtpServer, EmailModel.port);
                smtp.EnableSsl = false;
                smtp.Credentials = new NetworkCredential(EmailModel.EmailAddress, EmailModel.Password);
                smtp.Send(m);

                return true;
            }
            else
            {
                return false;
            }

        }

        public ExtendIdentityUser GetUserById(string id)
        {
            ExtendIdentityUser user = userManager.FindByIdAsync(id).Result;
            return user;
        }

        public bool EditUserGeneralSetting(UserGeneralSettingModel obj)
        {
            
            ExtendIdentityUser user = userManager.FindByIdAsync(obj.Id).Result;

            user.FirstName = obj.FirstName;
            user.MiddleName = obj.MiddleName;
            user.LastName = obj.LastName;
            user.PhoneNumber = obj.PhoneNumber;
            user.ExaminationTime = obj.ExaminationTime;
            db.SaveChanges();
            return true;
        }

        public bool EditEmail(EditEmailModel obj)
        {
            ExtendIdentityUser user = userManager.FindByIdAsync(obj.Id).Result;

            string emailtoken = userManager.GenerateChangeEmailTokenAsync(user, obj.NewEmail).Result;

            IdentityResult emailresult = userManager.ChangeEmailAsync(user, obj.NewEmail, emailtoken).Result;

            IdentityResult usernameresult = userManager.SetUserNameAsync(user, obj.NewEmail).Result;
            Task x = userManager.UpdateNormalizedUserNameAsync(user);

            if (emailresult.Succeeded && usernameresult.Succeeded)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool EditPassword(EditPasswordModel obj)
        {
            ExtendIdentityUser user = userManager.FindByIdAsync(obj.UserId).Result;

            IdentityResult newpassword = userManager.ChangePasswordAsync(user, obj.OldPassword, obj.NewPassword).Result;



            if (newpassword.Succeeded)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool IsAssistantExist()
        {
           int x = userManager.GetUsersInRoleAsync("Assistant").Result.Count();
            if(x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
