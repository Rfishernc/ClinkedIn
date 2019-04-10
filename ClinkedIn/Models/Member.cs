﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Member
    {

        public int Id { get; }
        public string Username { get; set; }
        static int idCounter = 0;

        // Interests type is placeholder change to correct type once implemented.
        public List<string> Interests { get; set; }
        //End comment

        public List<int> Friends { get; set; }
        public List<int> Enemies { get; set; }
        public List<string> Services { get; set; }

        public Member(MemberJoinRequest joinRequest)
        {
            Username = joinRequest.Username;
            Interests = joinRequest.Interests;
            Services = joinRequest.Services;
            Id = idCounter;
            idCounter++;
        }
    }
}
