using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("PatientProfile")]
    public class PatientProfile
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int GenderId { get; set; }

        public Gender gender { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string JobTitle { get; set; }

        public ICollection<PreAppointment> preAppointments { get; set; }

        public ICollection<MedicalHistory> medicalHistories { get; set; }

        public ICollection<MedicineHistory> medicineHistories { get; set; }

        public ICollection<PatientProcess> patientProcesses { get; set; }

        public ICollection<SurgeryHistory> surgeryHistories { get; set; }

        public ICollection<PatientProfileInsurancePackage> patientProfileInsurancePackages { get; set; }
    }
}
