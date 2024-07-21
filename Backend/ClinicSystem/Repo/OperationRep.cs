using ClinicSystem.Context;
using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class OperationRep : IOperationRep
    {
        private readonly DbContainer db;

        public OperationRep(DbContainer db)
        {
            this.db = db;
        }

        public bool AddOperation(Operation obj)
        {
            Operation op = new Operation();
            op.OperationName = obj.OperationName;
            op.Price = obj.Price;
            db.operation.Add(op);
            db.SaveChanges();
            foreach(var item in obj.insurancePackageOperation)
            {
                InsurancePackageOperation ipo = new InsurancePackageOperation();
                ipo.InsurancePackageId = item.InsurancePackageId;
                ipo.OperationId = op.Id;
                ipo.PaidByInsurance = item.PaidByInsurance;
                ipo.PaidByPatient = item.PaidByPatient;
                ipo.TotalPrice = item.PaidByInsurance + item.PaidByPatient;
                db.insurancePackageOperation.Add(ipo);
            }
            db.SaveChanges();
            return true;
        }

        public bool DeleteOperation(int id)
        {
            IEnumerable<InsurancePackageOperation> PO = db.insurancePackageOperation.Where(a => a.OperationId == id);
            foreach (var item in PO)
            {
                item.IsDeleted = true;
            }
            Operation obj = db.operation.Find(id);
            obj.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool EditOperation(Operation obj)
        {
            Operation op = db.operation.Find(obj.Id);
            op.OperationName = obj.OperationName;
            op.Price = obj.Price;
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return db.operation.Where(a=>a.IsDeleted == false).Select(a=>a);
        }

        public Operation GetOperationById(int id)
        {
            return db.operation.Find(id);
        }
    }
}
