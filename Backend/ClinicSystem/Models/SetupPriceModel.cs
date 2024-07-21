using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class SetupPriceModel
    {
        public string ExaminationName { get; set; } = "Examination";

        public string FollowupName { get; set; } = "Followup";

        public decimal ExaminationPrice { get; set; }

        public decimal FollowupPrice { get; set; }
    }
}
