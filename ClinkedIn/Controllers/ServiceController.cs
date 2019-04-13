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

        [HttpPost]
        // body should contain "MemberId" and "Services" (an array of string)
        public ActionResult<Member> AddMemberServices(AddService addServiceRequest)
        {
            // Gets member based on Id
            Member currentMemb = _memberRepo.GetMember(addServiceRequest.MemberId);

            currentMemb
                // gets services
                .Services
                // adds array of services to current services
                .AddRange(addServiceRequest.Services);

            return currentMemb;
        }

        [HttpDelete]
        public ActionResult<Member> RemoveMemberServices(RemoveService removeServiceRequest)
        {
            return _memberRepo.RemoveServices(removeServiceRequest);
        }
    }
}