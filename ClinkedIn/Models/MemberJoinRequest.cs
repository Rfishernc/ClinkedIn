using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class MemberJoinRequest
    {
        public string Username { get; set; }
        public List<int> Interests { get; set; }
        public List<string> Services { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
