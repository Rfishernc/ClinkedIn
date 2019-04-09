using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Database;
using ClinkedIn.Validators;
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

        [HttpPost("register")]
        public ActionResult<int> AddMember(MemberJoinRequest joinRequest)
    }
}