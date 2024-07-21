using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IInsuranceRep
    {
        IEnumerable<Insurance> GetAllInsurances();

        IEnumerable<CustomInsurance> GetAllInsurancesPackages();

        IEnumerable<CustomOperationPackage> GetOperationPackageByPackageId(int id);

        bool AddInsurancePackages(List<InsurancePackage> list);

        bool AddInsurancePackage(InsurancePackage obj);

        bool AddInsurance(Insurance obj);

        bool EditInsurance(Insurance obj);

        bool DeleteInsurance(int id);

        bool DeletePackage(int id);

        bool EditPackageName(InsurancePackage obj);

        bool EditPlanExaminationPricing(InsurancePackage obj);

        bool EditPlanFollowupPricing(InsurancePackage obj);

        bool EditPlanOperationsPricing(IEnumerable<InsurancePackageOperation> list);
    }
}
