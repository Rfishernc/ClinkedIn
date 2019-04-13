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
        public List<int> Interests { get; set; }
        public List<int> Friends { get; set; } = new List<int>();
        public List<int> Enemies { get; set; } = new List<int>();
        public List<string> Services { get; set; } = new List<string>();
        public DateTime ReleaseDate { get; set; }

        public Member()
        {
            Id = idCounter;
            idCounter++;
        }

        public Member(MemberJoinRequest joinRequest)
        {
            Username = joinRequest.Username;
            Interests = joinRequest.Interests;
            Services = joinRequest.Services;
            ReleaseDate = joinRequest.ReleaseDate;
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

        public List<Member> GetFriends()
        {
            var friendsList =
        }

        // converts interest IDs to strings
        public MemberWithInterestDescription ConvertInterests()
        {
            return new MemberWithInterestDescription(this);
        }

        public double DaysToRelease()
        {
            var daysBetween = Math.Floor((ReleaseDate - DateTime.Now).TotalDays);

            return daysBetween;
        }
    }
}
