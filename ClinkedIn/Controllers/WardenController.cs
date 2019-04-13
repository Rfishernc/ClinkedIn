using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using ClinkedIn.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardenController : ControllerBase
    {
        readonly MemberRepo _memberRepo;
        readonly WardenValidator _validator;
        readonly Warden _theWarden;

        public WardenController()
        {
            _memberRepo = new MemberRepo();
            _validator = new WardenValidator();
            _theWarden = new Warden() { WardenId = 123456 };
        }

        [HttpGet]
        public ActionResult GetInmates(GetInmatesRequest getInmatesRequest)
        {
            var validation = _validator.Validate(getInmatesRequest, _theWarden);
            if (!validation.IsValid)
            {
                return BadRequest( new { error = validation.ErrorMessage });
            }
            var memberList = MemberRepo._Members.Select(member => member.ConvertInterests()).ToList();
            return Accepted(memberList);
        }
    }
}