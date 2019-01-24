using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Controllers;
using Hadia.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Apis
{
    public class MemberController : BaseApiController
    {
        private HadiaContext _db;
        private IMapper _mapper;

        public MemberController(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet("/api/member")]
        public async Task<IActionResult> Get(int id)
        {
            var member = await _db.Mem_Masters
                .AsNoTracking()
                .Include(x => x.Photos)
                .Include(s => s.MembershipInGroups).ThenInclude(x => x.GroupMaster)
                .SingleOrDefaultAsync(x => x.Id == id && x.IsVarified);
            if (member == null)
                return NotFound();
            return Ok(_mapper.Map<DataMemberDto>(member));
        }
    }
}