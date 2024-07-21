using ClinicSystem.Privilage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    public class WorkingTime
    {
        public int Id { get; set; }

        public string extenidentityuserid { get; set; }

        public ExtendIdentityUser extendidentityuser { get; set; }

        public DayOfWeek Day { get; set;}

        public string DayName { get; set;}

        public DateTime from { get; set; }

        public DateTime to { get; set; }
    }
}
