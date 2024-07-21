using ClinicSystem.Context;
using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
    public class SetupRep:ISetupRep
    {
        private readonly DbContainer db;
        private readonly RoleManager<IdentityRole> roleManager;

        public SetupRep(DbContainer db, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.roleManager = roleManager;
        }

        public bool CheckPricing(string id)
        {
            decimal sum = db.doctorProcessPrice.Where(a => a.extendidentityuserid == id).Select(a => a.Price).Sum();
            if(sum == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckSetupStatus()
        {
          return db.setup.FirstOrDefault().IsSetup;
        }

        public bool ConfirmSetup()
        {
            Setup s = db.setup.FirstOrDefault();
            s.IsSetup = true;
            db.SaveChanges();
            return true;
        }

        public int GetOperationsCount()
        {
            return db.operation.Select(a => a.Id).Count();
        }

        public SuggestedOperationInsurancePricingModel GetSuggestedOperationPricing(int PackageId, int OperationId)
        {
            InsurancePackage ip = db.insurancePackage.Find(PackageId);

            decimal paidbypatientrate = (decimal)ip.ExaminationPaidByPatient / (decimal)ip.ExaminationTotalPrice;
            decimal operationprice = db.operation.Find(OperationId).Price;
            SuggestedOperationInsurancePricingModel res = new SuggestedOperationInsurancePricingModel();
            res.Total = operationprice;
            res.PaidByPatient = paidbypatientrate * operationprice;
            res.PaidByInsurance = operationprice - res.PaidByPatient;
            return res;
        }

        public bool SetupAppointmentTypes(List<AppointmentType> types)
        {
            foreach (var item in types)
            {
                db.appointmentType.Add(item);
            }

            ProcessType e = new ProcessType();
            e.ProcessName = "Examination";
            db.processType.Add(e);
            ProcessType f = new ProcessType();
            f.ProcessName = "Followup";
            db.processType.Add(f);

            IdentityRole d = new IdentityRole();
            d.Name = "Doctor";
            IdentityResult x = roleManager.CreateAsync(d).Result;

            IdentityRole a = new IdentityRole();
            a.Name = "Assistant";
            IdentityResult y = roleManager.CreateAsync(a).Result;

            db.SaveChanges();

            return true;
        }

        public bool SetupGenders(List<Gender> genders)
        {
            foreach (var item in genders)
            {
                db.gender.Add(item);
            }
            db.SaveChanges();
            return true;
        }

        public bool SetupInsurancePackages(List<InsurancePackageModel> inurancePackages)
        {
            foreach (var item in inurancePackages)
            {
                InsurancePackage obj = new InsurancePackage();
                obj.PackageName = item.PackageName;
                obj.InsuranceId = item.InsuranceId;
                obj.ExaminationPaidByPatient = item.ExaminationPaidByPatient;
                obj.ExaminationPaidByInsurance = item.ExaminationPaidByInsurance;
                obj.ExaminationTotalPrice = item.ExaminationPaidByPatient + item.ExaminationPaidByInsurance;
                obj.FollowupPaidByPatient = item.FollowupPaidByPatient;
                obj.FollowupPaidByInsurance = item.FollowupPaidByInsurance;
                obj.FollowupTotalPrice = item.FollowupPaidByPatient + item.FollowupPaidByInsurance;
                db.insurancePackage.Add(obj);
            }
            db.SaveChanges();
            return true;
        }

        public bool SetupInsurancePackagesOperation(List<InsurancePackageOperation> inurancePackagesOperations)
        {
            foreach(var item in inurancePackagesOperations)
            {
                InsurancePackageOperation obj = new InsurancePackageOperation();
                obj.InsurancePackageId = item.InsurancePackageId;
                obj.OperationId = item.OperationId;
                obj.PaidByInsurance = item.PaidByInsurance;
                obj.PaidByPatient = item.PaidByPatient;
                obj.TotalPrice = obj.PaidByInsurance + obj.PaidByPatient;
                db.insurancePackageOperation.Add(obj);
            }
            db.SaveChanges();
            return true;
        }

        public bool SetupInsurances(List<Insurance> insurances)
        {
            foreach (var item in insurances)
            {
                db.insurance.Add(item);
            }
            db.SaveChanges();
            return true;
        }

        public bool SetupOperations(List<Operation> operations)
        {
            foreach (var item in operations)
            {
                db.operation.Add(item);
            }
            db.SaveChanges();
            return true;
        }
    }
}
