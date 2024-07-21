using ClinicSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface IGenderRep
    {
        bool AddGender(Gender obj);

        bool EditGender(Gender obj);

        bool DeleteGender(int id);

        IEnumerable<Gender> GetAllGenders();

        Gender GetGenderById(int id);
    }
}
