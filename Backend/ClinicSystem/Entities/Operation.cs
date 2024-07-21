using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Operation")]
    public class Operation
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string OperationName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public ICollection<PatientProcessOperation> patientProcessOperations { get; set; }

        public ICollection<InsurancePackageOperation> insurancePackageOperation { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
