using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorCalendarModel
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public DateTime DateTime { get; set; }

        public int Status { get; set; }
    }
}
