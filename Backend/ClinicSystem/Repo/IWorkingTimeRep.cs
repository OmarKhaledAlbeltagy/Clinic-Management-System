using ClinicSystem.Entities;
using ClinicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IWorkingTimeRep
    {
        bool CheckDoctorWorkingTime(string id);

        IEnumerable<WorkingTimeModel> GetDoctorWorkingDays(string id);

        bool AddDoctorWorkingTime(WorkingTime obj);

        bool DeleteWorkingTime(int id);

        bool EditWorkingTime(WorkingTime obj);
    }
}
