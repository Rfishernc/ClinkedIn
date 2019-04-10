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
    }
}


