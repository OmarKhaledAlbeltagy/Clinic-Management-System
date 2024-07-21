using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class InsurancePackageModel
    {
        public int InsuranceId { get; set; }

        public string PackageName { get; set; }

        public decimal? ExaminationPaidByPatient { get; set; }

        public decimal? ExaminationPaidByInsurance { get; set; }

        public decimal? FollowupPaidByPatient { get; set; }

        public decimal? FollowupPaidByInsurance { get; set; }
    }
}
