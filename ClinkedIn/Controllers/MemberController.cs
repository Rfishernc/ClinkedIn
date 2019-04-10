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
    public class MemberController : ControllerBase
    {
        readonly MemberRepo _memberRepo;

        public MemberController()
        {
            _memberRepo = new MemberRepo();
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id) => _memberRepo.GetMember(id);

        [HttpGet()]
        public ActionResult<> GetFriends(int id)
        {

        }

    }
}
