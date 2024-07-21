using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorVacationModel
    {
        public int Id { get; set; }

        public string DoctorId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
