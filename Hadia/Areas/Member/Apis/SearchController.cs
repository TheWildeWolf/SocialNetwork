using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Apis
{
    public class SearchController : BaseApiController
    {
        private HadiaContext _db;
        private IMapper _mapper;

        public SearchController(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("/api/search")]
        public async Task<IActionResult> Search(string name, int batchId=0, int chapterId=0)
        {
            try
            {
                var members = await _db.Mem_Masters.Where(x => x.IsVarified)
                    .AsNoTracking()
                    .Include(x => x.Photos)
                    .Include(x => x.MainGroup)
                    .Include(x => x.UgCollege)
                    .Include(s => s.MembershipInGroups)
                    .ThenInclude(x => x.GroupMaster)
                    .Select(x => _mapper.Map<MemberSearchDto>(x))
                    .ToListAsync();

                if (batchId != 0)
                    members = members.Where(x => x.BatchId == batchId).ToList();

                if (chapterId != 0)
                    members = members.Where(x => x.ChapterId == chapterId).ToList();

                if (!string.IsNullOrEmpty(name))
                    members = members.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();

                return Ok(members);
            }
            catch (Exception e)
            {
                
                throw e;
            }

        }
    }
}