using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("LaboratoryInvestigation")]
    public class LaboratoryInvestigation
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string InvestigationName { get; set; }

        [MaxLength(10000)]
        public string InvestigationNote { get; set; }

        [MaxLength(10000)]
        public string ResultNote { get; set; }

        [MaxLength(200)]
        public string SuggestedLaboratory { get; set; }

        public int PatientProcessId { get; set; }

        public PatientProcess patientProcess { get; set; }
    }
}
