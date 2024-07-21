using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("PatientProfileInsurancePackage")]
    public class PatientProfileInsurancePackage
    {
        public int Id { get; set; }

        public int PatientProfileId { get; set; }

        public PatientProfile patientProfile { get; set; }

        public int InsurancePackageId { get; set; }

        public InsurancePackage insurnacePackage { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
