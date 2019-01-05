using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    [Route("api/[controller]")]
    public class FeedController : BaseApiController
    {
        private readonly HadiaContext _db;
        private readonly IMapper _mapper;
        public FeedController(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
                .Take(5)
                .Select( n=>_mapper.Map<FeedDto>(n))
                .ToListAsync();
            return Ok(listOfTimeLine);
        }

        //[HttpGet]
        public async Task<ActionResult<IEnumerable<FeedDto>>> GetA(int pageNumber=1)
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
                .Skip(5 * pageNumber).Take(5).ToListAsync();
            return listOfTimeLine;
        }
    }
}