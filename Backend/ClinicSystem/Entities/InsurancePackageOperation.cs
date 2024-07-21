using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    public class InsurancePackageOperation
    {
        public int Id { get; set; }

        public int InsurancePackageId { get; set; }

        public InsurancePackage insurancePackage { get; set; }

        public int OperationId { get; set; }

        public Operation operation { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaidByPatient { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaidByInsurance { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
