using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        readonly MemberRepo _memberRepo;

        public ServiceController()
        {
            _memberRepo = new MemberRepo();
        }

        [HttpGet]
        public ActionResult<Member> AddMemberServices(AddService addServiceRequest)
        {
            Member currentMemb = _memberRepo.GetMember(addServiceRequest.MemberId);

            currentMemb.Services.AddRange(addServiceRequest.Services);

            return currentMemb;
        }
    }
}