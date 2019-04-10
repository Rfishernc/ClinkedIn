using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class MemberRepo
    {
        static List<Member> _Members = new List<Member>()
        {
            // ======= Seed data for members =======
            new Member()
            {
                Username = "Dave"
            },
            new Member()
            {
                Username = "Jessica"
            },
            new Member()
            {
                Username = "Debbie"
            }
        };

        // Add member to list
        public Member AddMember(Member newMember)
            {
                _Members.Add(newMember);
                return newMember;
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

        public List<Member> FindMembersByInterest(int[] interestIds)
        {
            List<Member> matchedMembers = new List<Member>();
            foreach (var member in _Members)
            {
                foreach (var interestId in interestIds)
                {
                    if(member.Interests.Contains(interestId))
                    {
                        matchedMembers.Add(member);
                    }
                }
            }

            
            return matchedMembers.Distinct().ToList();
        }
    }
}


