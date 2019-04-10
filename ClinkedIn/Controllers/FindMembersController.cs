using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindMembersController : ControllerBase
    {
        readonly MemberRepo _memberRepo;

        public FindMembersController()
        {
            _memberRepo = new MemberRepo();
        }

        [HttpGet]
        public ActionResult<List<Member>> GetMembersByInterest()
        {
            _memberRepo.FindMembersByInterest()
            return new List<Member>();
        }
    }
}