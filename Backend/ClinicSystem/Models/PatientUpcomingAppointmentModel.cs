using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class PatientUpcomingAppointmentModel
    {
        public int AppointmentId { get; set; }

        public string Patientname { get; set; }

        public string DoctorName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Notes { get; set; }

        public string ProcessType { get; set; }

        public string CreationDate { get; set; }

        public string CreationTime { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateTime { get; set; }

        public bool? AttendanceStatus { get; set; }
    }
}
