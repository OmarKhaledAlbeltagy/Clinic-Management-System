using ClinicSystem.Context;
using ClinicSystem.Models;
using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class ProcessTypeRep : IProcessTypeRep
    {
        private readonly DbContainer db;

        public ProcessTypeRep(DbContainer db)
        {
            this.db = db;
        }

        public bool EditProcessPricing(IEnumerable<EditPricingModel> list)
        {
            foreach (var item in list)
            {
                DoctorProcessPrice DPP = db.doctorProcessPrice.Find(item.Id);
                DPP.Price = item.Price;
            }
            db.SaveChanges();
            return true;
        }

        public IEnumerable<ProcessType> GetAllProcesses()
        {
            IEnumerable<ProcessType> res = db.processType.Select(a => a);
            return res.OrderBy(a => a.ProcessName);
        }

        public IEnumerable<ProcessPriceModel> GetMyProcessPricing(string id)
        {
            IEnumerable<ProcessPriceModel> res = db.doctorProcessPrice.Where(a => a.extendidentityuserid == id).Join(db.processType, a => a.processtypeid, b => b.Id, (a, b) => new ProcessPriceModel
            {
                Id = a.Id,
                ProcessId = b.Id,
                ProcessName = b.ProcessName,
                Price = a.Price
            }).OrderBy(x => x.ProcessName);

            return res;
        }
    }
}
