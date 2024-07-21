using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class PatientNotAttendCountmodel
    {
        public string PatientName { get; set; }

        public int NotAttendCount { get; set; }

        public List<PatientNotAttendlistmodel> list { get; set; }
    }
}
