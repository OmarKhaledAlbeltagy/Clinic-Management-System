using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class ProcessPriceModel
    {
        public int Id { get; set; }

        public int ProcessId { get; set; }

        public string ProcessName { get; set; }

        public decimal Price { get; set; }
    }
}
