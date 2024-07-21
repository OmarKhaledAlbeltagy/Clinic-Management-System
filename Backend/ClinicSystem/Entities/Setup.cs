using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Entities
{
    [Table("Setup")]
    public class Setup
    {
        public int Id { get; set; }

        public bool IsSetup { get; set; } = false;
    }
}
