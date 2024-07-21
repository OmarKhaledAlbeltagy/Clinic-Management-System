using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("WorkingTimeByDate")]
    public class WorkingTimeByDate
    {
        public int Id { get; set; }

        public string extendidentityuserid { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
