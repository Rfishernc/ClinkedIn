using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class MemberWithInterestDescription
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<string> Interests { get; set; } = new List<string>();
        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }

        public MemberWithInterestDescription(Member member)
        {
            Id = member.Id;
            Username = member.Username;
            Friends = member.Friends;
            Enemies = member.Enemies;
            Services = member.Services;

            var singleInterest = typeof(EInterests).GetFields();

            var interests = member.Interests;
            // loop over interest id's and return description
            foreach (var interest in interests)
            {
                var interestAttributes = singleInterest[interest + 1].CustomAttributes.ToList();
                var interestDescription = interestAttributes[0].ConstructorArguments[0].Value.ToString();

                Interests.Add(interestDescription);
            }
        }
    }
}
