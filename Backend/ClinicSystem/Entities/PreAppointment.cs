using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("PreAppointment")]
    public class PreAppointment
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public int ProcessTypeId { get; set; }

        public ProcessType processType { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public DateTime AppointmentCreationDateTime { get; set; }

        public DateTime? LastEditedDateTime { get; set; }

        [MaxLength(2000)]
        public string Notes { get; set; }

        public int AppointmentTypeId { get; set; }

        public AppointmentType appointmentType { get; set; }

        public int? PatientProcessId { get; set; }

        public PatientProcess patientProcess { get; set; }

        public string DoctorId { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }

        public int? PatientProfileId { get; set; }

        public PatientProfile patientprofile { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<AppointmentsToCancel> appointmentsToCancel { get; set; }
    }
}
