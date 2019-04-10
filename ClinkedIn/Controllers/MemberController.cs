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
        public ActionResult<Member> GetMember(int id) => _memberRepo.GetMember(id);

        [HttpGet("enemies")]
        public ActionResult GetEnemies(GetEnemiesRequest enemiesRequest)
        {
            if (!_validator.ValidateGetEnemies())
            {
                return BadRequest(new { error = "Required info missing." });
            }
            var user = _memberRepo.GetMember(enemiesRequest.MemberId);
            var enemiesList = user.GetEnemies();
            return Accepted($"api/members/{user.Id}/enemies", enemiesList);
        }

        [HttpPost("enemies")]
        public ActionResult AddEnemy(AddEnemyRequest addEnemyRequest)
        {
            if (!_validator.ValidateAddEnemy())
            {
                return BadRequest(new { error = "Required info missing." });
            }
            var user = _memberRepo.GetMember(addEnemyRequest.MemberId);
            user.Enemies.Add(addEnemyRequest.EnemyId);

            return Accepted($"api/members/{user.Id}/enemies", user.Enemies);
        }

        [HttpDelete("enemies")]
        public ActionResult RemoveEnemy(RemoveEnemyRequest removeEnemyRequest)
        {
            if (!_validator.ValidateRemoveEnemy())
            {
                return BadRequest(new { error = "Required info missing." });
            }
            var user = _memberRepo.GetMember(removeEnemyRequest.MemberId);
            user.Enemies.Remove(removeEnemyRequest.EnemyId);

            return Accepted($"api/members/{user.Id}/enemies", user.Enemies);
        }
    }
}