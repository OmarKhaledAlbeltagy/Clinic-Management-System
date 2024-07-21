using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("DoctorProcessPrice")]
    public class DoctorProcessPrice
    {
        public int Id { get; set; }

        public string extendidentityuserid { get; set; }

        public ExtendIdentityUser extendIdentityUser { get; set; }

        public int processtypeid { get; set; }

        public ProcessType ProcessType { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
