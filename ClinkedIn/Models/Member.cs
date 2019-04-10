using ClinkedIn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string Username { get; set; }
        static int idCounter = 0;

        // Interests type is placeholder change to correct type once implemented.
        public List<string> Interests { get; set; }
        //End comment

        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }

        public Member()
        {

        }

        public Member(MemberJoinRequest joinRequest)
        {
            Username = joinRequest.Username;
            Interests = joinRequest.Interests;
            Services = joinRequest.Services;
            Id = idCounter;
            idCounter++;
        }

        public List<Member> GetEnemies()
        {
            var enemies = from enemy in Enemies
                           join member in MemberRepo._Members on enemy equals member.Id
                           select member;
            return enemies.ToList();
        }
    }
}
