using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class MemberJoinValidator
    {
        //Validates that proper new member info was submitted for username, interests, services, and release date.

        public ValidationResponse Validate(MemberJoinRequest request)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                return new ValidationResponse(false, "No username submitted");
            } else if (request.Interests.Count == 0)
            {
                return new ValidationResponse(false, "No interests submitted");
            } else if (request.Services.Count == 0)
            {
                return new ValidationResponse(false, "No services submitted");
            } else if ((request.ReleaseDate - DateTime.Now).TotalMilliseconds <= 0)
            {
                return new ValidationResponse(false, "Release date invalid.");
            }
            return new ValidationResponse(true);
        }
    }
}
