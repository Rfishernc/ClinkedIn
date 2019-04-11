using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResponse(bool isValid)
        {
            IsValid = isValid;
        }

        public ValidationResponse(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
    }
}
