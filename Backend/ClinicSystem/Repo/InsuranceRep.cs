using ClinicSystem.Context;
using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class InsuranceRep : IInsuranceRep
    {
        private readonly DbContainer db;

        public InsuranceRep(DbContainer db)
        {
            this.db = db;
        }

        public bool AddInsurance(Insurance obj)
        {
            db.insurance.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool AddInsurancePackage(InsurancePackage obj)
        {
            InsurancePackage n = new InsurancePackage();
            n.PackageName = obj.PackageName;
            n.InsuranceId = obj.InsuranceId;
            n.ExaminationPaidByPatient = obj.ExaminationPaidByPatient;
            n.ExaminationPaidByInsurance = obj.ExaminationPaidByInsurance;
            n.ExaminationTotalPrice = n.ExaminationPaidByPatient + n.ExaminationPaidByInsurance;
            n.FollowupPaidByPatient = obj.FollowupPaidByPatient;
            n.FollowupPaidByInsurance = obj.FollowupPaidByInsurance;
            n.FollowupTotalPrice = n.FollowupPaidByPatient + n.FollowupPaidByInsurance;
            db.insurancePackage.Add(n);
            db.SaveChanges();
            IEnumerable<int> OperationsIds = db.operation.Select(a => a.Id);

            foreach (var item in OperationsIds)
            {
                InsurancePackageOperation newobj = new InsurancePackageOperation();
                newobj.InsurancePackageId = n.Id;
                newobj.OperationId = item;
                newobj.PaidByInsurance = 0;
                newobj.PaidByPatient = db.operation.Find(item).Price;
                newobj.TotalPrice = db.operation.Find(item).Price;
                db.insurancePackageOperation.Add(newobj);
            }

            db.SaveChanges();
            return true;
        }

        public bool AddInsurancePackages(List<InsurancePackage> list)
        {
            foreach (var item in list)
            {
                db.insurancePackage.Add(item);
            }
            db.SaveChanges();
            return true;
        }

        public bool DeleteInsurance(int id)
        {
            Insurance i = db.insurance.Find(id);
            IEnumerable<InsurancePackage> ip = db.insurancePackage.Where(a => a.InsuranceId == id);
            foreach (var item in ip)
            {
                IEnumerable<InsurancePackageOperation> list = db.insurancePackageOperation.Where(a => a.InsurancePackageId == item.Id);

                foreach (var ipo in list)
                {
                    InsurancePackageOperation oldipo = db.insurancePackageOperation.Find(ipo.Id);
                    oldipo.IsDeleted = true;
                }
                InsurancePackage oldip = db.insurancePackage.Find(item.Id);
                oldip.IsDeleted = true;
            }
            i.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool DeletePackage(int id)
        {
            IEnumerable<InsurancePackageOperation> IPO = db.insurancePackageOperation.Where(a => a.InsurancePackageId == id);
            foreach (var item in IPO)
            {
                item.IsDeleted = true;
            }
            InsurancePackage IP = db.insurancePackage.Find(id);
            IP.IsDeleted = true;
            db.SaveChanges();
            return true;
        }

        public bool EditInsurance(Insurance obj)
        {
            Insurance old = db.insurance.Find(obj.Id);
            old.InsuranceName = obj.InsuranceName;
            db.SaveChanges();
            return true;
        }

        public bool EditPackageName(InsurancePackage obj)
        {
            InsurancePackage old = db.insurancePackage.Find(obj.Id);
            old.PackageName = obj.PackageName;
            db.SaveChanges();
            return true;
        }

        public bool EditPlanExaminationPricing(InsurancePackage obj)
        {
            InsurancePackage old = db.insurancePackage.Find(obj.Id);
            old.ExaminationPaidByPatient = obj.ExaminationPaidByPatient;
            old.ExaminationPaidByInsurance = obj.ExaminationPaidByInsurance;
            old.ExaminationTotalPrice = obj.ExaminationPaidByPatient + obj.ExaminationPaidByInsurance;
            db.SaveChanges();
            return true;
        }

        public bool EditPlanFollowupPricing(InsurancePackage obj)
        {
            InsurancePackage old = db.insurancePackage.Find(obj.Id);
            old.FollowupPaidByPatient = obj.FollowupPaidByPatient;
            old.FollowupPaidByInsurance = obj.FollowupPaidByInsurance;
            old.FollowupTotalPrice = obj.FollowupPaidByPatient + obj.FollowupPaidByInsurance;
            db.SaveChanges();
            return true;
        }

        public bool EditPlanOperationsPricing(IEnumerable<InsurancePackageOperation> list)
        {
            foreach (var item in list)
            {
                InsurancePackageOperation old = db.insurancePackageOperation.Where(a => a.InsurancePackageId == item.InsurancePackageId && a.OperationId == item.OperationId).FirstOrDefault();
                old.PaidByPatient = item.PaidByPatient;
                old.PaidByInsurance = item.PaidByInsurance;
                old.TotalPrice = old.PaidByPatient + old.PaidByInsurance;
            }
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Insurance> GetAllInsurances()
        {
            return db.insurance.Where(a => a.IsDeleted == false);
        }

        public IEnumerable<CustomInsurance> GetAllInsurancesPackages()
        {
            List<CustomInsurance> res = new List<CustomInsurance>();
            IEnumerable<Insurance> withoutplans = db.insurance.Where(a => a.IsDeleted == false);
            IEnumerable<CustomInsurance> withplans = db.insurance.Where(a=>a.IsDeleted == false).Join(db.insurancePackage, a => a.Id, b => b.InsuranceId, (a, b) => new CustomInsurance
            {
                Id = a.Id,
                InsuranceName = a.InsuranceName,
                insurancePackages = db.insurancePackage.Where(x => x.InsuranceId == a.Id && x.IsDeleted == false).OrderBy(c=>c.PackageName)
            }).OrderBy(a=>a.InsuranceName).DistinctBy(a=>a.Id);
            foreach (var item in withplans)
            {
                res.Add(item);
            }
            foreach (var item in withoutplans)
            {
                if(withplans.Where(a=>a.Id == item.Id).Count() == 0)
                {
                    CustomInsurance obj = new CustomInsurance();
                    obj.Id = item.Id;
                    obj.InsuranceName = item.InsuranceName;
                    res.Add(obj);
                }
                else
                {

                }
                
            }
            return res;
        }

        public IEnumerable<CustomOperationPackage> GetOperationPackageByPackageId(int id)
        {
            IEnumerable<CustomOperationPackage> res = db.insurancePackageOperation.Where(a => a.InsurancePackageId == id && a.IsDeleted == false).Join(db.operation, a => a.OperationId, b => b.Id, (a, b) => new CustomOperationPackage
            {
                Id = a.Id,
                OperationId = a.OperationId,
                OperationName = b.OperationName,
                PaidByPatient = a.PaidByPatient,
                PaidByInsurance = a.PaidByInsurance,
                TotalPrice = a.TotalPrice,
                IsDeleted = b.IsDeleted
            }).Where(a=>a.IsDeleted == false).OrderBy(x => x.OperationName);

            return res;
        }
    }
}
