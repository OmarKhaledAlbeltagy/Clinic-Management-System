using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("PatientProcessOperation")]
    public class PatientProcessOperation
    {
        public int Id { get; set; }

        public int PatientProcessId { get; set; }

        public PatientProcess patientProcess { get; set; }

        public int OperationId { get; set; }

        public Operation operation { get; set; }

        [MaxLength(10000)]
        public string Note { get; set; }

        public int OperationOriginalPrice { get; set; }

        public int OperationPriceAfterDiscount { get; set; }

        public string DoctorId { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }
    }
}
