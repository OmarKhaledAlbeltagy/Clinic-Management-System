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
    public class PreAppointmentRep:IPreAppointmentRep
    {
        private readonly DbContainer db;
        private readonly UserManager<ExtendIdentityUser> userManager;
        private readonly ITimeRep ti;

        public PreAppointmentRep(DbContainer db, UserManager<ExtendIdentityUser> userManager,ITimeRep ti)
        {
            this.db = db;
            this.userManager = userManager;
            this.ti = ti;
        }

        public bool CreateAppointment(CreateAppointmentModel obj)
        {
            DateTime now = ti.GetCurrentTime();
            if(obj.Id == null || obj.Id == 0)
            {
                PreAppointment res = new PreAppointment();
                res.PatientProfileId = null;
                res.AppointmentCreationDateTime = now;
                res.FirstName = obj.FirstName;
                res.MiddleName = obj.MiddleName;
                res.LastName = obj.LastName;
                res.ProcessTypeId = obj.ProcessId;
                res.AppointmentTypeId = obj.AppointmentTypeId;
                res.AppointmentDateTime = obj.DateTime;
                res.DoctorId = obj.DoctorId;
                if(obj.Notes == string.Empty || obj.Notes == null)
                {
                    res.Notes = null;
                }
                else
                {
                    res.Notes = obj.Notes;
                }
                res.PhoneNumber = obj.PhoneNumber;
                db.preAppointment.Add(res);
                db.SaveChanges();
                return true;
            }
            else
            {
                PatientProfile p = db.patientProfile.Find(obj.Id);
                PreAppointment res = new PreAppointment();
                res.PatientProfileId = obj.Id;
                res.AppointmentCreationDateTime = now;
                res.FirstName = p.FirstName;
                res.MiddleName = p.MiddleName;
                res.LastName = p.LastName;
                res.ProcessTypeId = obj.ProcessId;
                res.AppointmentTypeId = obj.AppointmentTypeId;
                res.AppointmentDateTime = obj.DateTime;
                res.DoctorId = obj.DoctorId;
                if (obj.Notes == string.Empty || obj.Notes == null)
                {
                    res.Notes = null;
                }
                else
                {
                    res.Notes = obj.Notes;
                }
                res.PhoneNumber = p.PhoneNumber;
                db.preAppointment.Add(res);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteAppointment(int id)
        {
            PreAppointment res = db.preAppointment.Find(id);
            AppointmentsToCancel atc = db.appointmentsToCancel.Where(a => a.IsDeleted == false && a.PreAppointmentId == id).FirstOrDefault();
            if (atc != null)
            {
                atc.status = "Canceled";
            }
            
            res.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool EditAppointment(EditAppointmentModel obj)
        {
            DateTime now = ti.GetCurrentTime();
            PreAppointment old = db.preAppointment.Find(obj.Id);
            if (old.AppointmentDateTime != obj.DateTime)
            {
                AppointmentsToCancel atc = db.appointmentsToCancel.Where(a => a.IsDeleted == false && a.PreAppointmentId == obj.Id).FirstOrDefault();
                if(atc != null)
                {
                    atc.status = "Edited";
                }
                
            }
            
            if (obj.PatientId == null || obj.Id == 0)
            {
                old.LastEditedDateTime = now;
                old.FirstName = obj.FirstName;
                old.MiddleName = obj.MiddleName;
                old.LastName = obj.LastName;
                old.AppointmentDateTime = obj.DateTime;
                old.AppointmentTypeId = obj.AppointmentTypeId;
                old.DoctorId = obj.DoctorId;
                if (obj.Notes == string.Empty || obj.Notes == null)
                {
                    old.Notes = null;
                }
                else
                {
                    old.Notes = obj.Notes;
                }
                old.PatientProfileId = obj.PatientId;
                old.PhoneNumber = obj.PhoneNumber;
                old.ProcessTypeId = obj.ProcessId;
                db.SaveChanges();
                return true;
            }
            else
            {
                PatientProfile p = db.patientProfile.Find(obj.PatientId);
                old.LastEditedDateTime = now;
                old.PatientProfileId = obj.PatientId;
                old.FirstName = p.FirstName;
                old.MiddleName = p.MiddleName;
                old.LastName = p.LastName;
                old.ProcessTypeId = obj.ProcessId;
                old.AppointmentTypeId = obj.AppointmentTypeId;
                old.AppointmentDateTime = obj.DateTime;
                old.DoctorId = obj.DoctorId;
                if (obj.Notes == string.Empty || obj.Notes == null)
                {
                    old.Notes = null;
                }
                else
                {
                    old.Notes = obj.Notes;
                }
                old.PhoneNumber = p.PhoneNumber;
                db.SaveChanges();
                return true;
            }
           
        }

        public CustomPatientPreAppointment GetAppointmentDetails(int id)
        {
            PreAppointment pre = db.preAppointment.Find(id);
            ExtendIdentityUser Doctor = userManager.FindByIdAsync(pre.DoctorId).Result;
            CustomPatientPreAppointment res = new CustomPatientPreAppointment();
            res.Id = id;
            res.AppointmentType = db.appointmentType.Find(pre.AppointmentTypeId).AppointmentTypeName;
            res.ProcessType = db.processType.Find(pre.ProcessTypeId).ProcessName;
            res.CreationDate = pre.AppointmentCreationDateTime.ToString("dddd dd/MM/yyyy");
            res.CreationTime = pre.AppointmentCreationDateTime.ToString("hh:mm tt");
            res.Date = pre.AppointmentDateTime.ToString("dddd dd/MM/yyyy");
            res.Time = pre.AppointmentDateTime.ToString("hh:mm tt");
            res.DateTime = pre.AppointmentDateTime;
            res.DoctorName = Doctor.FirstName+" "+Doctor.MiddleName+" "+Doctor.LastName;
            res.PatientName = pre.FirstName + " " + pre.MiddleName + " " + pre.LastName;
            res.PhoneNumber = pre.PhoneNumber;
            res.Notes = pre.Notes;

            return res;
        }

        public IEnumerable<PatientUpcomingAppointmentModel> GetAppointmentsToCancel()
        {
            DateTime today = ti.GetCurrentTime().Date;
            IEnumerable<PatientUpcomingAppointmentModel> res = db.appointmentsToCancel.Where(a => a.IsDeleted == false && a.status == null).Join(db.preAppointment, a => a.PreAppointmentId, b => b.Id, (a, b) => new
            {
                Id = b.Id,
                PatientName = b.FirstName + " " + b.MiddleName + " " + b.LastName,
                DoctorId = b.DoctorId,
                Date = b.AppointmentDateTime.ToString("dddd dd/MM/yyyy"),
                Time = b.AppointmentDateTime.ToString("hh:mm tt"),
                CreationDate = b.AppointmentCreationDateTime.ToString("dddd dd/MM/yyyy"),
                CreationTime = b.AppointmentCreationDateTime.ToString("hh:mm tt"),
                DateTime = b.AppointmentDateTime,
                Notes = b.Notes,
                ProcessTypeId = b.ProcessTypeId
            }).Where(a=>a.DateTime.Date >= today).Join(db.Users, a => a.DoctorId, b => b.Id, (a, b) => new
            {
                AppointmentId = a.Id,
                PatientName = a.PatientName,
                DoctorName = b.FirstName + " " + b.MiddleName + " " + b.LastName,
                Date = a.Date,
                Time = a.Time,
                CreationDate = a.CreationDate,
                CreationTime = a.CreationTime,
                DateTime = a.DateTime,
                Notes = a.Notes,
                ProcessTypeId = a.ProcessTypeId
            }).Join(db.processType,a=>a.ProcessTypeId,b=>b.Id,(a,b)=>new PatientUpcomingAppointmentModel
            {
                AppointmentId = a.AppointmentId,
                Patientname = a.PatientName,
                DoctorName = a.DoctorName,
                Date = a.Date,
                Time = a.Time,
                CreationDate = a.CreationDate,
                CreationTime = a.CreationTime,
                DateTime = a.DateTime,
                Notes = a.Notes,
                ProcessType = b.ProcessName
            }).OrderBy(a => a.DateTime);

            return res;

        }

        public IEnumerable<DateTime> GetDoctorAvailableDates(string DoctorId)
        {
            DateTime now = ti.GetCurrentTime();


            List<DateTime> res = db.workingTimeByDate.Where(a => a.extendidentityuserid == DoctorId && a.From.Date >= now.Date).Select(c => c.From).ToList();
            
            
            IEnumerable<Vacation> v = db.vacation.Where(a => a.IsDeleted == false && a.DoctorId == DoctorId);
            foreach (var item in v)
            {
                if(item.From.TimeOfDay == new TimeSpan(0,0,0) && item.To.TimeOfDay == new TimeSpan(0,0,0))
                {
                    DateTime rem = item.From;
                    res.Remove(rem);
                }
            }
            return res.OrderBy(a=>a.Date);


        }

        public IEnumerable<DoctorAvailableTimeByDateModel> GetDoctorAvailableTimes(GetDoctorAvailableTimeModel obj)
        {
            int x = (int)userManager.FindByIdAsync(obj.DoctorId).Result.ExaminationTime;
            TimeSpan examinationtime = new TimeSpan(0, x, 0);
            DateTime start = db.workingTimeByDate.Where(a => a.extendidentityuserid == obj.DoctorId && a.From.Date == obj.Date.Date).FirstOrDefault().From;
            DateTime end = db.workingTimeByDate.Where(a => a.extendidentityuserid == obj.DoctorId && a.From.Date == obj.Date.Date).FirstOrDefault().To;
            IEnumerable<Vacation> v = db.vacation.Where(a => a.DoctorId == obj.DoctorId && a.IsDeleted == false && a.From.Date <= obj.Date.Date);
            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.DoctorId == obj.DoctorId && a.AppointmentDateTime.Date == obj.Date.Date && a.IsDeleted == false);
            List<DoctorAvailableTimeByDateModel> res = new List<DoctorAvailableTimeByDateModel>();

           
                for (int i = 0; i < 100; i++)
                {
                    
                    
                 DoctorAvailableTimeByDateModel result = new DoctorAvailableTimeByDateModel();
                    result.Value = start.ToString(" HH:mm:ss");
                    result.Date = start.ToString("hh:mm tt");
                    result.checkvalue = start;
                    res.Add(result);
             
               
                    
                    start = start.Add(examinationtime);
                    if(start == end)
                    {
                        break;
                    }
                }

         

            List<DoctorAvailableTimeByDateModel> ress = new List<DoctorAvailableTimeByDateModel>();

            foreach (var r in res)
            {
                PreAppointment pree = pre.Where(a => a.AppointmentDateTime.TimeOfDay == r.checkvalue.TimeOfDay).FirstOrDefault();
                if(pree == null)
                {
                    ress.Add(r);
                }
            }
            List<DoctorAvailableTimeByDateModel> resss = new List<DoctorAvailableTimeByDateModel>();
            foreach (var r in ress)
            {
                Vacation vac = v.Where(a => a.From <= r.checkvalue && a.To >= r.checkvalue).FirstOrDefault();
                if (vac == null)
                {
                    resss.Add(r);
                }
            }

            return resss.OrderBy(a => a.checkvalue);
            
            

        }

        public IEnumerable<DoctorCalendarModel> GetDoctorCalendar(string DoctorId)
        {
            DateTime now = ti.GetCurrentTime();
            DateTime start = now.AddMonths(-3);
            DateTime end = now.AddMonths(3);
            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.DoctorId == DoctorId && a.AppointmentDateTime >= start && a.AppointmentDateTime <= end && a.IsDeleted == false);
            List<DoctorCalendarModel> res = new List<DoctorCalendarModel>();
            foreach (var item in pre)
            {
                DoctorCalendarModel x = new DoctorCalendarModel();
                x.Id = item.Id;
                x.PatientName = item.FirstName + " " + item.MiddleName;
                x.DateTime = item.AppointmentDateTime;
                if (item.AppointmentDateTime >= now)
                {
                    x.Status = 0;
                }
                else
                {
                    if(item.PatientProcessId == null)
                    {
                        x.Status = 2;
                    }
                    else
                    {
                        x.Status = 1;
                    }
                }
                res.Add(x);
            }

            return res;
        }

     

        public IEnumerable<ExtendIdentityUser> GetDoctors()
        {
            IEnumerable<ExtendIdentityUser> res = userManager.GetUsersInRoleAsync("Doctor").Result;

            return res.OrderBy(a => a.FirstName).OrderBy(a => a.MiddleName).OrderBy(a => a.LastName);
        }

        public CustomPreAppointment GetPatientAppointmentById(int id)
        {
            PreAppointment obj = db.preAppointment.Find(id);
            CustomPreAppointment res = new CustomPreAppointment();
            res.Id = obj.Id;
            res.FirstName = obj.FirstName;
            res.MiddleName = obj.MiddleName;
            res.LastName = obj.LastName;
            res.PhoneNumber = obj.PhoneNumber;
            res.DoctorId = obj.DoctorId;
            res.AppointmentTypeId = obj.AppointmentTypeId;
            res.ProcessTypeId = obj.ProcessTypeId;
            res.Notes = obj.Notes;
            res.AppointmentDateTime = obj.AppointmentDateTime.Date;
            res.TimeValue = obj.AppointmentDateTime.ToString(" HH:mm:ss");
            res.TimeText = obj.AppointmentDateTime.ToString("hh:mm tt");
            res.PatientProfileId = obj.PatientProfileId;
                
            return res;
        }

        public IEnumerable<CustomPatientPreAppointment> GetPatientAppointmentByPhoneNumber(string phone)
        {
            DateTime now = ti.GetCurrentTime();
            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.PhoneNumber == phone && a.IsDeleted == false && a.PatientProcessId == null && a.AppointmentDateTime.Date >= now.Date);

            IEnumerable<CustomPatientPreAppointment> res = pre.Join(db.Users, a => a.DoctorId, b => b.Id, (a, b) => new
            {
                Id = a.Id,
                PatientName = a.FirstName + " " + a.MiddleName + " " + a.LastName,
                DoctorName = b.FirstName + " " + b.MiddleName + " " + b.LastName,
                PhoneNumber = a.PhoneNumber,
                ProcessTypeId = a.ProcessTypeId,
                AppointmentTypeId = a.AppointmentTypeId,
                Notes = a.Notes,
                Date = a.AppointmentDateTime.ToString("dddd dd/MM/yyyy"),
                Time = a.AppointmentDateTime.ToString("hh:mm tt"),
                DateTime = a.AppointmentDateTime,
                CreationDate = a.AppointmentCreationDateTime.ToString("dddd dd/MM/yyyy"),
                CreationTime = a.AppointmentCreationDateTime.ToString("hh:mm tt"),
            }).Join(db.processType, a => a.ProcessTypeId, b => b.Id, (a, b) => new
            {
                Id = a.Id,
                PatientName = a.PatientName,
                DoctorName = a.DoctorName,
                PhoneNumber = a.PhoneNumber,
                ProcessType = b.ProcessName,
                AppointmentTypeId = a.AppointmentTypeId,
                Notes = a.Notes,
                Date = a.Date,
                Time = a.Time,
                DateTime = a.DateTime,
                CreationDate = a.CreationDate,
                CreationTime = a.CreationTime
            }).Join(db.appointmentType, a => a.AppointmentTypeId, b => b.Id, (a, b) => new CustomPatientPreAppointment
            {
                Id = a.Id,
                PatientName = a.PatientName,
                DoctorName = a.DoctorName,
                PhoneNumber = a.PhoneNumber,
                ProcessType = a.ProcessType,
                AppointmentType = b.AppointmentTypeName,
                Notes = a.Notes,
                Date = a.Date,
                Time = a.Time,
                DateTime = a.DateTime,
                CreationDate = a.CreationDate,
                CreationTime = a.CreationTime
            }).OrderBy(a => a.DateTime);

            return res;
        }

        public PatientProfile GetPatientByPhoneNumber(string phone)
        {
            PatientProfile res = db.patientProfile.Where(a => a.PhoneNumber == phone).FirstOrDefault();
            return res;
        }

        public PatientUpcomingAppointmentModel GetPatientUpcomingAppointments(string phone)
        {
            DateTime now = ti.GetCurrentTime();
            PreAppointment p = db.preAppointment.Where(a => a.PhoneNumber == phone && a.PatientProcessId == null && a.AppointmentDateTime.Date >= now.Date).FirstOrDefault();

            
            if(p == null)
            {
                return null;
            }

            else
            {
                ExtendIdentityUser Doctor = userManager.FindByIdAsync(p.DoctorId).Result;
                PatientUpcomingAppointmentModel res = new PatientUpcomingAppointmentModel();
                res.AppointmentId = p.Id;
                res.Patientname = p.FirstName + " " + p.MiddleName + " " + p.LastName;
                res.DoctorName = Doctor.FirstName + " " + Doctor.MiddleName + " " + Doctor.LastName;
                res.Date = p.AppointmentDateTime.ToString("dddd dd/MM/yyyy");
                res.Time = p.AppointmentDateTime.ToString("hh:mm tt");
                res.CreationDate = p.AppointmentCreationDateTime.ToString("dddd dd/MM/yyyy");
                res.CreationTime = p.AppointmentCreationDateTime.ToString("hh:mm tt");
                return res;
            }
        }

        public IEnumerable<PatientUpcomingAppointmentModel> GetTodayAppointments(string DoctorId)
        {
            DateTime today = ti.GetCurrentTime();

            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.DoctorId == DoctorId && a.AppointmentDateTime.Date == today.Date && a.IsDeleted == false);
            List<PatientUpcomingAppointmentModel> res = new List<PatientUpcomingAppointmentModel>();
            TimeSpan allowed = new TimeSpan(0, 15, 0);
            foreach (var item in pre)
            {
                PatientUpcomingAppointmentModel x = new PatientUpcomingAppointmentModel();
                x.AppointmentId = item.Id;
                x.Patientname = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                x.Time = item.AppointmentDateTime.ToString("hh:mm tt");
                x.CreationDate = item.AppointmentCreationDateTime.ToString("dd/MM/yyyy");
                x.CreationTime = item.AppointmentCreationDateTime.ToString("hh:mm tt");
                x.Notes = item.Notes;
                x.DateTime = item.AppointmentDateTime;
                x.ProcessType = db.processType.Find(item.ProcessTypeId).ProcessName;
                x.PhoneNumber = item.PhoneNumber;
                if(item.AppointmentDateTime.TimeOfDay.Add(allowed) < today.TimeOfDay)
                {
                    x.AttendanceStatus = false;
                }
                else
                {
                    if (item.AppointmentDateTime.TimeOfDay.Add(allowed) >= today.TimeOfDay)
                    {
                        x.AttendanceStatus = true;
                    }
                }
                res.Add(x);
            }
            return res.OrderBy(a => a.DateTime);
        }

        public PatientNotAttendCountmodel PatientNotAttend(string phone)
        {
            DateTime now = ti.GetCurrentTime();
            IEnumerable<PreAppointment> pre = db.preAppointment.Where(a => a.PhoneNumber == phone && a.PatientProcessId == null && a.AppointmentDateTime.Date <= now.Date);
            if(pre == null)
            {
                return null;
            }
            else
            {
                PatientNotAttendCountmodel res = new PatientNotAttendCountmodel();
                List<PatientNotAttendlistmodel> l = new List<PatientNotAttendlistmodel>();
                res.NotAttendCount = pre.Select(a => a.Id).Count();
                res.PatientName = pre.FirstOrDefault().FirstName + " " + pre.FirstOrDefault().MiddleName + " " + pre.FirstOrDefault().LastName;
                foreach (var item in pre)
                {
                    ExtendIdentityUser doctor = userManager.FindByIdAsync(item.DoctorId).Result;
                    PatientNotAttendlistmodel x = new PatientNotAttendlistmodel();
                    x.Date = item.AppointmentDateTime.ToString("dddd dd/MM/yyyy");
                    x.Time = item.AppointmentDateTime.ToString("hh:mm tt");
                    x.DoctorName = doctor.FirstName + " " + doctor.MiddleName + " " + doctor.LastName;
                    x.DateTime = item.AppointmentDateTime;
                    l.Add(x);
                }
                l.OrderByDescending(a => a.DateTime);
                res.list = l;

                return res;
            }
            
        }
    }
}
