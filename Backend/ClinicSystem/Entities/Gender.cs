using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Gender")]
    public class Gender
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string GenderName { get; set; }

        public ICollection<PatientProfile> patientProfiles { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
