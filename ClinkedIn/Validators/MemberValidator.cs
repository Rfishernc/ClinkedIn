﻿using ClinkedIn.Data;
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

        //Validates that a proper member Id was submitted and that member has enemies for get enemies request.

        public ValidationResponse ValidateGetEnemies(int request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (_members.GetMember(request).Enemies.Count == 0)
            {
                return new ValidationResponse(false, "Member has no enemies.");
            }

            return new ValidationResponse(true);
        }

        //Validates that a proper member Id and enemyId  were submitted and that the enemy is not already on members enemy list for add enemy request.

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

        //Validates that a proper member Id and enemyId  were submitted and that the enemy is on members enemy list for remove enemy request.

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

        //Validates that a proper member Id was submitted and that the member has not been previously released for get days to release request.

        public ValidationResponse ValidateGetReleaseDays(int request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (_members.GetMember(request).DaysToRelease() <= 0)
            {
                return new ValidationResponse(false, "You've already been released. Get outta here!");
            }

            return new ValidationResponse(true);
        }


        public bool ValidateGetFriends()
        {
            return true;
        }


        public bool ValidateAddFriends()
        {
            return true;
        }

        public bool ValidateDeleteFriends()
        {
            return true;
        }

        public ValidationResponse ValidateFriendsFriends(int request)
        {
            if (MemberRepo._Members.Where(member => member.Id == request).Count() == 0)
            {
                return new ValidationResponse(false, "Invalid member Id. No member found with matching Id.");
            } else if (MemberRepo._Members.First(member => member.Id == request).Friends.Count == 0)
            {
                return new ValidationResponse(false, "You don't have any friends, loser.");
            }
                return new ValidationResponse(true);

        }
    }
}
