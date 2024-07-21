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
   public interface IPreAppointmentRep
    {
        PatientProfile GetPatientByPhoneNumber(string phone);

        IEnumerable<ExtendIdentityUser> GetDoctors();

        IEnumerable<DateTime> GetDoctorAvailableDates(string DoctorId);

        IEnumerable<DoctorAvailableTimeByDateModel> GetDoctorAvailableTimes(GetDoctorAvailableTimeModel obj);

        bool CreateAppointment(CreateAppointmentModel obj);

        IEnumerable<CustomPatientPreAppointment> GetPatientAppointmentByPhoneNumber(string phone);

        bool DeleteAppointment(int id);

        CustomPreAppointment GetPatientAppointmentById(int id);

        bool EditAppointment(EditAppointmentModel obj);

        PatientUpcomingAppointmentModel GetPatientUpcomingAppointments(string phone);

        PatientNotAttendCountmodel PatientNotAttend(string phone);

        IEnumerable<DoctorCalendarModel> GetDoctorCalendar(string DoctorId);

        CustomPatientPreAppointment GetAppointmentDetails(int id);

        IEnumerable<PatientUpcomingAppointmentModel> GetTodayAppointments(string DoctorId);

        IEnumerable<PatientUpcomingAppointmentModel> GetAppointmentsToCancel();

    }
}
