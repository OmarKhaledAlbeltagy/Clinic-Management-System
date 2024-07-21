using ClinicSystem.Context;
using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using ClinicSystem.Privilage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class VacationRep:IVacationRep
    {
        private readonly DbContainer db;
        private readonly UserManager<ExtendIdentityUser> userManager;
        private readonly ITimeRep ti;

        public VacationRep(DbContainer db, UserManager<ExtendIdentityUser> userManager, ITimeRep ti)
        {
            this.db = db;
            this.userManager = userManager;
            this.ti = ti;
        }

        public bool CreateVacation(DoctorVacationModel obj)
        {
            Vacation v = new Vacation();
         
            v.DoctorId = obj.DoctorId;
            v.From = obj.From;
            v.To = obj.To;
            db.vacation.Add(v);
            db.SaveChanges();
            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.IsDeleted == false && a.AppointmentDateTime >= obj.From && a.AppointmentDateTime <= obj.To && a.DoctorId == obj.DoctorId);
            if(pre == null)
            {
                return true;
            }
            else
            {
                foreach (var item in pre)
                {
                    AppointmentsToCancel ap = new AppointmentsToCancel();
                    ap.PreAppointmentId = item.Id;
                    ap.status = null;
                    ap.VacationId = v.Id;
                    db.appointmentsToCancel.Add(ap);
                }
                db.SaveChanges();
                return true;
            }
           

        }

        public bool DeleteVacation(int id)
        {
            Vacation v = db.vacation.Find(id);
            v.IsDeleted = true;
            IEnumerable<AppointmentsToCancel> aps = db.appointmentsToCancel.Where(a => a.VacationId == id);
            db.vacation.Remove(v);
            foreach (var item in aps)
            {
                item.IsDeleted = true;
            }
            
            
            db.SaveChanges();
            return true;
        }

        public IEnumerable<FromToModel> GetDoctorVacations(string id)
        {
            DateTime now = ti.GetCurrentTime();
            DateTime start = now.AddMonths(-6);
            DateTime end = start.AddYears(1);
            List<FromToModel> res = new List<FromToModel>();
            IEnumerable<Vacation> v = db.vacation.Where(a => a.DoctorId == id && a.From.Date >= start.Date && a.To.Date <= end.Date && a.IsDeleted == false);
            foreach (var item in v)
            {
                FromToModel m = new FromToModel();
                m.Id = item.Id;
                m.From = item.From;
                m.To = item.To;
                res.Add(m);
            }

            return res;
        }

        public bool IsFullDayVacancy(DoctorAvailabeTimeModel obj)
        {
            DateTime from = new DateTime(obj.Date.Year, obj.Date.Month, obj.Date.Day, 0, 0, 0);
            DateTime dd = obj.Date.AddDays(1);
            DateTime to = new DateTime(dd.Year, dd.Month, dd.Day, 0, 0, 0);
            Vacation v = db.vacation.Where(a => a.From == from && a.To == to && a.DoctorId == obj.DoctorId && a.IsDeleted == false).FirstOrDefault();

            if(v == null)
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
