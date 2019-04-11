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
        static int idCounter = 0;
        public List<string> Interests { get; set; }
        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }

        public MemberWithInterestDescription(Member member, Enum en)
        {
            //var interests = member.Interests;
            //Type type = en.GetType();

            //MemberInfo[] memInfo = type.GetMember(en.ToString());
            //foreach (var interest in interests)
            //{
            //    ;
            //    Console.Write(x);
            //}

            int value = 1;
            var description = (EInterests)value;
            var x = typeof(EInterests).CustomAttributes;
        }
    }
}
