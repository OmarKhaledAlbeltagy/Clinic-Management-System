﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class DoctorRegisterModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? ExaminationTime { get; set; }

        public string RoleName { get; set; } = "Doctor";

        public string Password { get; set; }

        public bool Active { get; set; } = true;
    }
}
