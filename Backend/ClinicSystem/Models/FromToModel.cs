using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class FromToModel
    {
        public int? Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
