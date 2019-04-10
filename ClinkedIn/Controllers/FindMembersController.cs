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


        /* to hit get request properly, pass JSON in the body shaped like this:
         * ====================================================================
         * {
	     *   "InterestIds": [int] // interest ids to match members by 
         * }
         * ====================================================================
         * 
         * It will return an array of members with all related properties
         */
        [HttpGet]
        public ActionResult<List<Member>> GetMembersByInterest(InterstFilter interestIds)
        {
            var matchedMembers = _memberRepo.FindMembersByInterest(interestIds);
            return matchedMembers;
        }
    }
}