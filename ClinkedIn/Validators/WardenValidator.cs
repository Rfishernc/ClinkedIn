﻿using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    //Validates that proper warden id was submitted for warden requests.

    public class WardenValidator
    {
        public ValidationResponse Validate(GetInmatesRequest request, Warden warden)
        {
            if (request.Id != warden.WardenId)
            {
                return new ValidationResponse(false, "Incorrect id code.");
            }
            return new ValidationResponse(true);
        }
    }
}
