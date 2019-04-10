using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class MemberJoinRequest
    {
        public string Username { get; set; }
        public List<string> Interests { get; set; }
        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }
    }
}
