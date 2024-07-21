using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("CheifComplaint")]
    public class CheifComplaint
    {
        public int Id { get; set; }

        [MaxLength(10000)]
        public string CheifComplaintExplaination { get; set; }

        public int PatientProcessId { get; set; }

        public PatientProcess patientProcess { get; set; }

        [MaxLength(10000)]
        public string Note { get; set; }
    }
}
