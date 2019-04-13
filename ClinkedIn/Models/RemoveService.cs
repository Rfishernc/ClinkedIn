using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class RemoveService
    {
        public int MemberId { get; set; }
        public List<string> Services { get; set; }
    }
}
