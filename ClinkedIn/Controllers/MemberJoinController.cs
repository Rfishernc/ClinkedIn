using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Validators;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberJoinController : ControllerBase
    {
        readonly MemberRepo _Members;
        readonly MemberJoinValidator _Validator;

        public MemberJoinController()
        {
            _Members = new MemberRepo();
            _Validator = new MemberJoinValidator();
        }

        /* Send the following in the body
        * Username: string,
        * Interests: [int],
        * Services: [string],
        * ReleaseDate: DateTime
        * Adds a new member to database with the submitted information.  Returns the newly created member with Id.  */

        [HttpPost("join")]
        public ActionResult AddMember(MemberJoinRequest joinRequest)
        {
            var validation = _Validator.Validate(joinRequest);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }
            var newMember = new Member(joinRequest);
            _Members.AddNewMember(newMember);

            return Created($"api/members/{newMember.Id}", newMember);
        }
    }
}