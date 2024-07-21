using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class GetDoctorAvailableTimeModel
    {
        public string DoctorId { get; set; }

        public DateTime Date { get; set; }
    }
}
