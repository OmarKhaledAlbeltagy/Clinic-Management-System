using ClinicSystem.Context;
using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class AppointmentTypeRep : IAppointmentTypeRep
    {
        private readonly DbContainer db;

        public AppointmentTypeRep(DbContainer db)
        {
            this.db = db;
        }
        public bool AddAppointmentType(AppointmentType obj)
        {
            db.appointmentType.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool DeleteAppointmentType(int id)
        {
            AppointmentType obj = db.appointmentType.Find(id);
            obj.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool EditAppointmentType(AppointmentType obj)
        {
            AppointmentType old = db.appointmentType.Find(obj.Id);
            old.AppointmentTypeName = obj.AppointmentTypeName;
            db.SaveChanges();
            return true;
        }

        public IEnumerable<AppointmentType> GetAllAppointmentTypes()
        {
            return db.appointmentType.Where(a => a.IsDeleted == false);
        }

        public AppointmentType GetAppointmentTypeById(int id)
        {
            return db.appointmentType.Find(id);
        }
    }
}
