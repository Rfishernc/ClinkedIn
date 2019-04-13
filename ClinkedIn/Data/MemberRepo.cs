using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class MemberRepo
    {
        public static List<Member> _Members = new List<Member>()
        {
            // ======= Seed data for members =======
            new Member()
            {
                Username = "Dave",
                Interests = new List<int>(){0,1},
                ReleaseDate = new DateTime(2019, 8, 24),
                Friends = new List<int>(){2}
            },
            new Member()
            {
                Username = "Jessica",
                Interests = new List<int>(){0,2,3},
                ReleaseDate = new DateTime(2020, 5, 15),
                Friends = new List<int>(){0,2}
            },
            new Member()
            {
                Username = "Debbie",
                Interests = new List<int>(){1,3,4},
                ReleaseDate = new DateTime(2050, 3, 20),
                Friends = new List<int>(){0,1}
            },
            new Member()
            {
                Username = "Member",
                Interests = new List<int>(){1,3},
                ReleaseDate = new DateTime(2050, 3, 20),
                Friends = new List<int>(){}
            }
        };

        public void AddNewMember(Member newMember)
        {
            _Members.Add(newMember);
        }

        // give access to list from other files
        public List<Member> exposeMembers() => _Members;

        public Member GetMember(int memberId)
        {
            Member selectedMember = _Members
            // finds member based on Id
            .Find(member => member.Id == memberId);

            return selectedMember;
        }

        public List<Member> FindMembersByInterest(InterstFilter interestIds)
        {
            List<Member> matchedMembers = new List<Member>();
            foreach (var member in _Members)
            {
                // Validation to ensure any members with no interets are skipped
                if(member.Interests != null)
                {
                    foreach (var interestId in interestIds.InterestIds)
                    {
                        if(member.Interests.Contains(interestId))
                        {
                            matchedMembers.Add(member);
                        }
                    }
                }
            }
            // remove duplicate members that matched on multiple IDs
            return matchedMembers.Distinct().ToList();
        }

        public int[] RemoveInterest(RemoveInterest interestsToRemove)
        {
            Member currentMemb = GetMember(interestsToRemove.MemberId);
            if (!currentMemb.Interests.Intersect(interestsToRemove.InterestId).Any())
            {
                throw new Exception("Ya done goofed");
            }
            currentMemb.Interests.RemoveAll(membersInterests => 
            interestsToRemove
            .InterestId
            .Contains(membersInterests));

            return interestsToRemove.InterestId;
        }

        public Member RemoveServices(RemoveService removeServiceRequest)
        {
            // gets member by Id
            Member currentMemb = GetMember(removeServiceRequest.MemberId);

            /* for each service requested for removal
             * check if the member currently offers such service
             * and remove that service from their list
             */
            foreach (var service in removeServiceRequest.Services)
            {
                if (currentMemb.Services.Contains(service))
                {
                    currentMemb.Services.Remove(service);
                }
            }

            // return member with removed services
            return currentMemb;
        }
    }
}


