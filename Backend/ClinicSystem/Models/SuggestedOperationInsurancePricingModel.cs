using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class SuggestedOperationInsurancePricingModel
    {
        public decimal PaidByPatient { get; set; }

        public decimal PaidByInsurance { get; set; }

        public decimal Total { get; set; }
    }
}
