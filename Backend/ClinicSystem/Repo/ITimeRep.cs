using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Repo
{
   public interface ITimeRep
    {
        DateTime GetCurrentTime();
    }
}
