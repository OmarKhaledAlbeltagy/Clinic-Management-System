using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.CustomEntities
{
    public class CustomPreAppointment
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int ProcessTypeId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string TimeText { get; set; }

        public string TimeValue { get; set; }

        public string Notes { get; set; }

        public int AppointmentTypeId { get; set; }

        public string DoctorId { get; set; }

        public int? PatientProfileId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
