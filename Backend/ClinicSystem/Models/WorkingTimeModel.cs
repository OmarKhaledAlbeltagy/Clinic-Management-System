using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class WorkingTimeModel
    {
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }

        public string DayName { get; set; }

        public string from { get; set; }

        public DateTime fromdt { get; set; }

        public string to { get; set; }

        public DateTime todt { get; set; }
    }
}
