using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("AppointmentType")]
    public class AppointmentType
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string AppointmentTypeName { get; set; }

        public ICollection<PreAppointment> preAppointments { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
