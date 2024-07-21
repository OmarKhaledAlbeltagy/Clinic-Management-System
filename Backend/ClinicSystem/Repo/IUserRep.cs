using ClinicSystem.Models;
using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IUserRep
    {
        bool RegisterDoctor(DoctorRegisterModel obj);

        bool RegisterAssistant(AssistantRegisterModel obj);

        bool ActivateEmail(ConfirmEmailModel obj);

        bool ActivateEmailAndConfirmSetup(ConfirmEmailModel obj);

        bool ResendEmailConfirmation(string email);

        bool CheckEmailExist(string mail);

        bool CheckPhoneExist(string phone);

        ExtendIdentityUser GetUserById(string id);

        bool EditUserGeneralSetting(UserGeneralSettingModel obj);

        bool EditEmail(EditEmailModel obj);

        bool EditPassword(EditPasswordModel obj);

        bool IsAssistantExist();
    }
}
