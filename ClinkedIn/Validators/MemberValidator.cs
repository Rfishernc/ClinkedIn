using ClinkedIn.Data;
using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Validators
{
    public class MemberValidator
    {
        readonly MemberRepo _members;

        public MemberValidator()
        {
            _members = new MemberRepo();
        }

        public ValidationResponse ValidateGetEnemies(GetEnemiesRequest request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request.MemberId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (_members.GetMember(request.MemberId).Enemies.Count == 0)
            {
                return new ValidationResponse(false, "Member has no enemies.");
            }

            return new ValidationResponse(true);
        }

        public ValidationResponse ValidateAddEnemy(AddEnemyRequest request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request.MemberId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (MemberRepo._Members.Where(member => member.Id == request.EnemyId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid enemy Id. No member found with matching Id.");
            } else if (_members.GetMember(request.MemberId).Enemies.Contains(request.EnemyId))
            {
                return new ValidationResponse(false, "Enemy is already on member's enemy list.");
            }

            return new ValidationResponse(true);
        }

        public ValidationResponse ValidateRemoveEnemy(RemoveEnemyRequest request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request.MemberId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            }
            else if (MemberRepo._Members.Where(member => member.Id == request.EnemyId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid enemy Id. No member found with matching Id.");
            }
            else if (!_members.GetMember(request.MemberId).Enemies.Contains(request.EnemyId))
            {
                return new ValidationResponse(false, "Enemy is not on member's enemy list.");
            }

            return new ValidationResponse(true);
        }

        public ValidationResponse ValidateGetReleaseDays(GetReleaseDaysRequest request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request.MemberId).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (_members.GetMember(request.MemberId).DaysToRelease() <= 0)
            {
                return new ValidationResponse(false, "You've already been released. Get outta here!");
            }

            return new ValidationResponse(true);
        }
    }
}
