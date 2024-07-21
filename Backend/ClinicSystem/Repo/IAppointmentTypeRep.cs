using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IAppointmentTypeRep
    {
        bool AddAppointmentType(AppointmentType obj);

        bool EditAppointmentType(AppointmentType obj);

        bool DeleteAppointmentType(int id);

        IEnumerable<AppointmentType> GetAllAppointmentTypes();

        AppointmentType GetAppointmentTypeById(int id);
    }
}
