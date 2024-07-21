using ClinicSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class TimeRep : ITimeRep
    {
        private readonly DbContainer db;

        public TimeRep(DbContainer db)
        {
            this.db = db;
        }

        public DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Egypt Standard Time");

            return _localTime;
        }
    }
}
