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
    public class MemberController : ControllerBase
    {
        readonly MemberRepo _memberRepo;
        readonly MemberValidator _validator;

        public MemberController()
        {
            _memberRepo = new MemberRepo();
            _validator = new MemberValidator();
        }

        [HttpGet("{id}")]
        public ActionResult<MemberWithInterestDescription> GetMember(int id) => _memberRepo.GetMember(id).ConvertInterests();


        /* Send get to member id/enemies
         * Returns list of all members enemies with their information*/


        [HttpGet("{id}/enemies")]
        public ActionResult GetEnemies(int id)
        {
            var validation = _validator.ValidateGetEnemies(id);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }
            var user = _memberRepo.GetMember(id);
            var enemiesList = user.GetEnemies();
            return Accepted($"api/members/{user.Id}/enemies", enemiesList);
        }

        /* Send the following in the body
         * MemberId: int,
         * EnemyId: int
         * Adds requested enemy to members enemy list.  Returns members updated enemy list. */

        [HttpPost("enemies")]
        public ActionResult AddEnemy(AddEnemyRequest addEnemyRequest)
        {
            var validation = _validator.ValidateAddEnemy(addEnemyRequest);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }
            var user = _memberRepo.GetMember(addEnemyRequest.MemberId);
            user.Enemies.Add(addEnemyRequest.EnemyId);

            return Accepted($"api/members/{user.Id}/enemies", user.Enemies);
        }

        /* Send the following in the body
         * MemberId: int,
         * EnemyId: int
         * Removes requested enemy from members enemy list.  Returns members updated enemy list. */

        [HttpDelete("enemies")]
        public ActionResult RemoveEnemy(RemoveEnemyRequest removeEnemyRequest)
        {
            var validation = _validator.ValidateRemoveEnemy(removeEnemyRequest);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }
            var user = _memberRepo.GetMember(removeEnemyRequest.MemberId);
            user.Enemies.Remove(removeEnemyRequest.EnemyId);

            return Accepted($"api/members/{user.Id}/enemies", user.Enemies);
        }

        /*  Send member id in the url*/

        [HttpGet("{id}/friends")]
        public ActionResult GetFriends(int id)
        {
            if (!_validator.ValidateGetFriends())
            {
                return BadRequest();
            }
            var user = _memberRepo.GetMember(id);
            var friends = user.GetFriends();

            return Accepted($"api/members/{user.Id}/friends", friends);
        }

        /* Send get to member id/release
        * Returns number of days left in members sentence. */

        [HttpGet("{id}/release")]
        public ActionResult GetReleaseDays(int id)

        {
            var validation = _validator.ValidateGetReleaseDays(id);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }

            var user = _memberRepo.GetMember(id);
            var releaseDays = user.DaysToRelease() + " days till release.";

            return Accepted($"api/members/{user.Id}", releaseDays);
        }

    }
}
