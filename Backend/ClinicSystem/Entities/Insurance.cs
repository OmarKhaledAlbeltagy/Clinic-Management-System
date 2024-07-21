using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Insurance")]
    public class Insurance
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string InsuranceName { get; set; }

        public ICollection<InsurancePackage> insurancePackages { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
