using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Drugs")]
    public class Drugs
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string DrugName { get; set; }

        [MaxLength(1000)]
        public string Dose { get; set; }

        public int PatientProcessId { get; set; }

        public PatientProcess patientProcess { get; set; }
    }
}
