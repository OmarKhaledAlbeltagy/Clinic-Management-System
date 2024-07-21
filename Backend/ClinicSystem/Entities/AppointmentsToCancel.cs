using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    public class AppointmentsToCancel
    {
        public int Id { get; set; }

        public int PreAppointmentId { get; set; }

        public PreAppointment preAppointment { get; set; }

        public string status { get; set; }

        public int VacationId { get; set; }

        public Vacation vacation { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
