using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    public class MembersData
    {
        static List<Member> _Members { get; set; } = new List<Member>();
        static int _MemberIdCount = 0;

        public void AddNewMember(Member newMember)
        {
            _MemberIdCount++;
            newMember.Id = _MemberIdCount;
            _Members.Add(newMember);
        }
    }
}
