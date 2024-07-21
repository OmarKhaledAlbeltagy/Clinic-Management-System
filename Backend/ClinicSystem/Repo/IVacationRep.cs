using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IVacationRep
    {
        bool CreateVacation(DoctorVacationModel obj);

        IEnumerable<FromToModel> GetDoctorVacations(string id);

        bool DeleteVacation(int id);

        bool IsFullDayVacancy(DoctorAvailabeTimeModel obj);
    }
}
