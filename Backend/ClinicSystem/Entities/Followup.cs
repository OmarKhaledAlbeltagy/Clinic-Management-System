using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Followup")]
    public class Followup
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        //[ForeignKey("Examination")]
        public int ExaminationId { get; set; }

        [ForeignKey("ExaminationId")]
        public PatientProcess Examination { get; set; }

        //[ForeignKey("Followupp")]
        public int? FollowupId { get; set; }

        [ForeignKey("FollowupId")]
        public PatientProcess Followupp { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
