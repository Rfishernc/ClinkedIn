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
        readonly MembersData _Members;
        readonly MemberJoinValidator _Validator;

        public MemberJoinController()
        {
            _Members = new MembersData();
            _Validator = new MemberJoinValidator();
        }

        [HttpPost("join")]
        public ActionResult AddMember(MemberJoinRequest joinRequest)
        {
            if (!_Validator.Validate())
            {
                return BadRequest(new { error = "Required member info missing." });
            }
            var newMember = new Member(joinRequest);
            _Members.AddNewMember(newMember);

            return Created($"api/members/{newMember.Id}", newMember);
        }
    }
}