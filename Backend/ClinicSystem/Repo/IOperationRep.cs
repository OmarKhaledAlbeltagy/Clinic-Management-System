using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IOperationRep
    {
        bool AddOperation(Operation obj);

        IEnumerable<Operation> GetAllOperations();

        Operation GetOperationById(int id);

        bool DeleteOperation(int id);

        bool EditOperation(Operation obj);
    }
}
