using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("MedicalHistory")]
    public class MedicalHistory
    {
        public int Id { get; set; }

        [MaxLength(10000)]
        public string MedicalHistoryNotice { get; set; }

        public int PatientProfileId { get; set; }

        public PatientProfile patientProfile { get; set; }

        [MaxLength(10000)]
        public string Note { get; set; }
    }
}
