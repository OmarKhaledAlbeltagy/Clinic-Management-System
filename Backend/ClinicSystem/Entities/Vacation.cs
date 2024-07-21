using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    public class Vacation
    {
        public int Id { get; set; }

        public string DoctorId { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
