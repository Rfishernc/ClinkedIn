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


        [HttpGet("enemies")]
        public ActionResult GetEnemies(GetEnemiesRequest enemiesRequest)
        {
            var validation = _validator.ValidateGetEnemies(enemiesRequest);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }
            var user = _memberRepo.GetMember(enemiesRequest.MemberId);
            var enemiesList = user.GetEnemies();
            return Accepted($"api/members/{user.Id}/enemies", enemiesList);
        }

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

        [HttpGet("friends")]
        public ActionResult GetFriends(GetFriendsRequest getFriendsRequest)
        {
            if (!_validator.ValidateGetFriends())
            {
                return BadRequest();
            }
            var user = _memberRepo.GetMember(getFriendsRequest.FriendId);
            var friends = user.GetFriends();

            return Accepted($"api/members/{user.Id}/friends", user.Friends);


        }

        [HttpGet("release")]
        public ActionResult GetReleaseDays(GetReleaseDaysRequest releaseDaysRequest)
        {
            var validation = _validator.ValidateGetReleaseDays(releaseDaysRequest);
            if (!validation.IsValid)
            {
                return BadRequest(new { error = validation.ErrorMessage });
            }

            var user = _memberRepo.GetMember(releaseDaysRequest.MemberId);
            var releaseDays = user.DaysToRelease();

            return Accepted($"api/members/{user.Id}", releaseDays);
        }

    }
}
