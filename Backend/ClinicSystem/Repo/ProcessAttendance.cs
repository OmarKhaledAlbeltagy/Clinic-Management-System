using ClinicSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class ProcessAttendance: IProcessAttendance
    {
        private readonly DbContainer db;
        private readonly ITimeRep ti;

        public ProcessAttendance(DbContainer db, ITimeRep ti)
        {
            this.db = db;
            this.ti = ti;
        }
    }
}
