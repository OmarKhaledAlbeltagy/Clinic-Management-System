using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.CustomEntities
{
    public class CustomInsurancePackage
    {
        public int? Id { get; set; }

        public int InsuranceId { get; set; }

        public string PackageName { get; set; }

        public float? ExaminationDiscountRate { get; set; }

        public float? FollowupDiscountRate { get; set; }

        public float? OperationDiscountRate { get; set; }
    }
}
