using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("SurgeryHistory")]
    public class SurgeryHistory
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string SurgeryName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [MaxLength(10000)]
        public string Note { get; set; }

        public int PatientProfileId { get; set; }

        public PatientProfile patientProfile { get; set; }
    }
}
