using ClinicSystem.CustomEntities;
using ClinicSystem.Entities;
using ClinicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface ISetupRep
    {
        bool CheckSetupStatus();

        bool SetupAppointmentTypes(List<AppointmentType> types);

        bool SetupGenders(List<Gender> genders);

        bool SetupInsurances(List<Insurance> insurances);

        bool SetupInsurancePackages(List<InsurancePackageModel> inurancePackages);

        bool SetupInsurancePackagesOperation(List<InsurancePackageOperation> inurancePackagesOperations);

        bool SetupOperations(List<Operation> operations);

        bool ConfirmSetup();

        int GetOperationsCount();

        bool CheckPricing(string id);

        SuggestedOperationInsurancePricingModel GetSuggestedOperationPricing(int PackageId, int OperationId);


    }
}
