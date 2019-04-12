using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class RemoveInterest
    {
        public int MemberId { get; set; }
        public int[] InterestId { get; set; }
    }
}
