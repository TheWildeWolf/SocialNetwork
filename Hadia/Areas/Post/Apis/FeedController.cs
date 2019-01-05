using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    [Route("api/[controller]")]
    public class FeedController : BaseApiController
    {
        private readonly HadiaContext _db;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        public FeedController(HadiaContext db, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedDto>>> Get()
        {
            var involvedGroups = await _db.Post_GroupMembers
                .Where(s => s.IsActive && s.MemberId == UserId)
                .Select(s => s.GroupId).ToListAsync();
            involvedGroups.Add(_db.Mem_Masters.Find(UserId).GroupId ?? 0);
            var listOfTimeLine = await _db.Post_Masters
                .Where(x => x.GroupId == null || involvedGroups.Any(s => s == x.GroupId))
                .OrderByDescending(x=>x.CDate)
                .Include(x => x.PostImages)
                .Select( n=>_mapper.Map<FeedDto>(n))
                .Take(10).ToListAsync();
            return Ok(listOfTimeLine);
        }

        public async Task<ActionResult<IEnumerable<FeedDto>>> Get(int pageNumber)
        {
            var involvedGroups = await _db.Post_GroupMembers
                .Where(s => s.IsActive && s.MemberId == UserId)
                .Select(s => s.GroupId).ToListAsync();
            involvedGroups.Add(_db.Mem_Masters.Find(UserId).GroupId ?? 0);
            var listOfTimeLine = await _db.Post_Masters
                .Where(x => x.GroupId == null || involvedGroups.Any(s => s == x.GroupId))
                .OrderByDescending(x => x.CDate)
                .Include(x => x.PostImages)
                .Select(n => _mapper.Map<FeedDto>(n))
                .Skip(10 * pageNumber).Take(10).ToListAsync();
            return listOfTimeLine;
        }
    }
}