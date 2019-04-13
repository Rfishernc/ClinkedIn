using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class AddFriendRequest
    {
        public int MemberId { get; set; }
        public int FriendId { get; set; }
    }
}
