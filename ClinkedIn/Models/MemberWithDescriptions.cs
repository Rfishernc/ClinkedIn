using ClinkedIn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class MemberWithDescriptions
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<string> Interests { get; set; } = new List<string>();
        public List<string> Friends { get; set; }
        public List<string> Enemies { get; set; }
        public List<string> Services { get; set; }

        // Creates a member with a list of interests in string form
        public MemberWithDescriptions(Member member)
        {
            var members = new MemberRepo();
            Id = member.Id;
            Username = member.Username;
            Friends = member.Friends.Select(friendId => members.GetMember(friendId).Username).ToList();
            Enemies = member.Enemies.Select(enemyId => members.GetMember(enemyId).Username).ToList();
            Services = member.Services;


            var interests = member.Interests;

            var singleInterest = typeof(EInterests).GetFields();
            /* loop over interest id's and return description
             * Not sure why it is so difficult to get description info from Enums
             * A simple database will likely render this unecessary */
            foreach (var interest in interests)
            {
                var interestAttributes = singleInterest[interest + 1].CustomAttributes.ToList();
                var interestDescription = interestAttributes[0].ConstructorArguments[0].Value.ToString();

                Interests.Add(interestDescription);
            }
        }
    }
}
