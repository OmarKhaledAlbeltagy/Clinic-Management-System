using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("ProcessType")]
    public class ProcessType
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string ProcessName { get; set; }

        public ICollection<PatientProcess> patientProcesses { get; set; }

        public ICollection<PreAppointment> preAppointments { get; set; }
    }
}
