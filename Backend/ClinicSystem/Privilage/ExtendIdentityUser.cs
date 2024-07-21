using ClinicSystem.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Privilage
{
    public class ExtendIdentityUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int? ExaminationTime { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<Vacation> vacations { get; set; }
    }
}
