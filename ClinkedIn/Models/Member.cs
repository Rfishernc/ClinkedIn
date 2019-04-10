using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Member
    {

        public int Id { get; }
        public string Username { get; set; }

        // Interests type is placeholder change to correct type once implemented.
        public List<int> Interests { get; set; }
        //End comment

        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }

        // Make different Ids for each member
        static int idCounter = 0;

        public Member()
        {
            Id = idCounter;
            idCounter++;
        }
    }
}
