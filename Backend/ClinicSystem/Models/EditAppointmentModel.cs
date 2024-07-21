using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class EditAppointmentModel
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string DoctorId { get; set; }

        public DateTime DateTime { get; set; }

        public int ProcessId { get; set; }

        public int AppointmentTypeId { get; set; }

        public string Notes { get; set; }
    }
}
