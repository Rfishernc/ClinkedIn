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

        public Member AddMember(Member newMember)
            {
                _Members.Add(newMember);
                return newMember;
            }

        public List<Member> exposeMembers() => _Members;
    }
}


