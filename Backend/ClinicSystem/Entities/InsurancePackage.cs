using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("InsurancePackage")]
    public class InsurancePackage
    {
        public int Id { get; set; }

        public int InsuranceId { get; set; }

        public Insurance insurance { get; set; }

        [MaxLength(200)]
        public string PackageName { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExaminationTotalPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExaminationPaidByPatient { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExaminationPaidByInsurance { get; set; }

        [Column(TypeName = "money")]
        public decimal? FollowupTotalPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? FollowupPaidByPatient { get; set; }

        [Column(TypeName = "money")]
        public decimal? FollowupPaidByInsurance { get; set; }

        public ICollection<PatientProcess> patientProcesses { get; set; }

        public ICollection<InsurancePackageOperation> insurancePackageOperation { get; set; }

        public ICollection<PatientProfileInsurancePackage> patientProfileInsurancePackages { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
