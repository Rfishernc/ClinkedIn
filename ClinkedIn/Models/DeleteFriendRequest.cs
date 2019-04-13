using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class DeleteFriendRequest
    {
        public int MemberId { get; set; }
        public int FriendId { get; set; }
    }
}
