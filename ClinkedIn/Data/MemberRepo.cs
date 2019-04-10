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
    }
}


