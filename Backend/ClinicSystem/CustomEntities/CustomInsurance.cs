using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.CustomEntities
{
    public class CustomInsurance
    {
        public int? Id { get; set; }

        public string InsuranceName { get; set; }

        public IEnumerable<InsurancePackage> insurancePackages { get; set; }
    }
}
