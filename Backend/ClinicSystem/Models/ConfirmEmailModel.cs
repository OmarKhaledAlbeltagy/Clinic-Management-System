﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Models
{
    public class ConfirmEmailModel
    {
        public string Email { get; set; }

        public string token { get; set; }
    }
}
