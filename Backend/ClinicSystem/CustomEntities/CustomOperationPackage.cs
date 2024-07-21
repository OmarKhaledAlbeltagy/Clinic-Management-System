using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.CustomEntities
{
    public class CustomOperationPackage
    {
        public int Id { get; set; }

        public int OperationId { get; set; }

        public string OperationName { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? PaidByPatient { get; set; }

        public decimal? PaidByInsurance { get; set; }

        public bool IsDeleted { get; set; }
    }
}
