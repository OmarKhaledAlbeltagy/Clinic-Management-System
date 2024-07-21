using ClinicSystem.Context;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class WorkingTimeRep:IWorkingTimeRep
    {
        private readonly DbContainer db;

        public WorkingTimeRep(DbContainer db)
        {
            this.db = db;
        }

        public bool AddDoctorWorkingTime(WorkingTime obj)
        {
            string dayname = "";
            DateTime start = new DateTime();
            switch (obj.Day)
            {
                case DayOfWeek.Saturday:
                    dayname = "Saturday";
                    start = new DateTime(2022, 01, 01, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Sunday:
                    dayname = "Sunday";
                     start = new DateTime(2022,01,02,obj.from.Hour,obj.from.Minute,obj.from.Second);
                    
                    break;
                case DayOfWeek.Monday:
                    dayname = "Monday";
                     start = new DateTime(2022, 01, 03, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Tuesday:
                    dayname = "Tuesday";
                    start = new DateTime(2022, 01, 04, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Wednesday:
                    dayname = "Wednesday";
                     start = new DateTime(2022, 01, 05, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Thursday:
                    dayname = "Thursday";
                    start = new DateTime(2022, 01, 06, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Friday:
                    dayname = "Friday";
                     start = new DateTime(2022, 01, 07, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                
            }
            WorkingTime res = new WorkingTime();
            res.Day = obj.Day;
            res.DayName = dayname;
            res.from = obj.from;
            res.to = obj.to;
            res.extenidentityuserid = obj.extenidentityuserid;
            db.workingTime.Add(res);

            
            for (int i = 0; i <= 520; i++)
            {
                WorkingTimeByDate x = new WorkingTimeByDate();
                x.extendidentityuserid = obj.extenidentityuserid;
                x.From = start;
                x.To = new DateTime(start.Year, start.Month, start.Day, obj.to.Hour, obj.to.Minute, obj.to.Second);
                db.workingTimeByDate.Add(x);
                start = start.AddDays(7);
            }


            db.SaveChanges();
            return true;
        }

        public bool CheckDoctorWorkingTime(string id)
        {
            int x = db.workingTime.Where(a => a.extenidentityuserid == id).Count();
            if(x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DeleteWorkingTime(int id)
        {
            WorkingTime x = db.workingTime.Find(id);
            WorkingTime y = db.workingTime.Where(a=>a.Id != id && a.Day == x.Day && a.from.Hour == x.from.Hour && a.from.Minute == x.from.Minute && a.to.Hour == x.to.Hour && a.to.Minute == x.to.Minute).FirstOrDefault();
            if(y == null)
            {
                IEnumerable<WorkingTimeByDate> WTBD = db.workingTimeByDate.Where(a => a.From.DayOfWeek == x.Day && a.From.Hour == x.from.Hour && a.From.Minute == x.from.Minute);
                foreach (var item in WTBD)
                {
                    db.workingTimeByDate.Remove(item);
                }
            }
          
              
            db.workingTime.Remove(x);
            db.SaveChanges();
            return true;
        }

        public bool EditWorkingTime(WorkingTime obj)
        {
            WorkingTime old = db.workingTime.Find(obj.Id);
            IEnumerable<WorkingTimeByDate> WTBD = db.workingTimeByDate.Where(a => a.From.DayOfWeek == old.Day && a.From.Hour == old.from.Hour && a.From.Minute == old.from.Minute);
            foreach (var item in WTBD)
            {
                db.workingTimeByDate.Remove(item);
            }
            db.SaveChanges();
            old.Day = obj.Day;
            string dayname = "";
            switch (obj.Day)
            {
                case DayOfWeek.Sunday:
                    dayname = "Sunday";
            break;
                case DayOfWeek.Monday:
                    dayname = "Monday";
            break;
                case DayOfWeek.Tuesday:
                    dayname = "Tuesday";
            break;
                case DayOfWeek.Wednesday:
                    dayname = "Wednesday";
            break;
                case DayOfWeek.Thursday:
                    dayname = "Thursday";
            break;
                case DayOfWeek.Friday:
                    dayname = "Friday";
            break;
                case DayOfWeek.Saturday:
                    dayname = "Saturday";
            break;
            }
            old.DayName = dayname;
            old.from = obj.from;
            old.to = obj.to;


            
            
            DateTime start = new DateTime();
            switch (obj.Day)
            {
                case DayOfWeek.Saturday:
                    dayname = "Saturday";
                    start = new DateTime(2022, 01, 01, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Sunday:
                    dayname = "Sunday";
                    start = new DateTime(2022, 01, 02, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Monday:
                    dayname = "Monday";
                    start = new DateTime(2022, 01, 03, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Tuesday:
                    dayname = "Tuesday";
                    start = new DateTime(2022, 01, 04, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Wednesday:
                    dayname = "Wednesday";
                    start = new DateTime(2022, 01, 05, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Thursday:
                    dayname = "Thursday";
                    start = new DateTime(2022, 01, 06, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                case DayOfWeek.Friday:
                    dayname = "Friday";
                    start = new DateTime(2022, 01, 07, obj.from.Hour, obj.from.Minute, obj.from.Second);
                    break;
                
            }


            for (int i = 0; i <= 520; i++)
            {
                WorkingTimeByDate x = new WorkingTimeByDate();
                x.extendidentityuserid = old.extenidentityuserid;
                x.From = start;
                x.To = new DateTime(start.Year, start.Month, start.Day, obj.to.Hour, obj.to.Minute, obj.to.Second);
                db.workingTimeByDate.Add(x);
                start = start.AddDays(7);
            }


            db.SaveChanges();
            return true;

        }

        public IEnumerable<WorkingTimeModel> GetDoctorWorkingDays(string id)
        {
            IEnumerable<WorkingTime> w = db.workingTime.Where(a => a.extenidentityuserid == id);
            List<WorkingTimeModel> res = new List<WorkingTimeModel>();
            foreach (var item in w)
            {
                WorkingTimeModel x = new WorkingTimeModel();
                x.Id = item.Id;
                x.Day = item.Day;
                x.DayName = item.DayName;
                x.from = item.from.ToString("hh:mm tt");
                x.fromdt = item.from;
                x.to = item.to.ToString("hh:mm tt");
                x.todt = item.to;
                res.Add(x);
            }
            return res.OrderBy(a => a.Day);
        }
    }
}
