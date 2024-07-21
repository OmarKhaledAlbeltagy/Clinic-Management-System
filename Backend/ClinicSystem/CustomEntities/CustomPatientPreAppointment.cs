using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.CustomEntities
{
    public class CustomPatientPreAppointment
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }

        public string DoctorName { get; set; }

        public string ProcessType { get; set; }

        public string AppointmentType { get; set; }

        public string Notes { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public DateTime DateTime { get; set; }

        public string CreationDate { get; set; }

        public string CreationTime { get; set; }
    }
}
