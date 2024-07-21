using ClinicSystem.Entities;
using ClinicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IProcessTypeRep
    {
        IEnumerable<ProcessPriceModel> GetMyProcessPricing(string id);

        bool EditProcessPricing(IEnumerable<EditPricingModel> list);

        IEnumerable<ProcessType> GetAllProcesses();
    }
}
