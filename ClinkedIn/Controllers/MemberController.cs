﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Data;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        readonly MemberRepo _memberRepo;

        public MemberController()
        {
            _memberRepo = new MemberRepo();
        }



        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            Member selectedMember = _memberRepo
                // checks the member list
                .exposeMembers()
                // finds member based on Id
                .Find(member => member.Id == id);
            return selectedMember;
        }
    }
}