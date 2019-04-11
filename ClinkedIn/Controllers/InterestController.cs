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
    public class InterestController : ControllerBase
    {
        readonly MemberRepo _memberRepo;
        public InterestController()
        {
            _memberRepo = new MemberRepo();
        }

        /* Send the following in the body
         * InterestId: [array of integers]
         * MemberId: int*/
        [HttpDelete]
        public ActionResult<int[]> DeleteInterest(RemoveInterest interestRequest)
        {
            return _memberRepo.RemoveInterest(interestRequest);
        }
    }
}