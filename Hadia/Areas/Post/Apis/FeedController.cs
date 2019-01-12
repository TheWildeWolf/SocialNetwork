using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
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
        public async Task<ActionResult<IEnumerable<FeedDto>>> Get(int offset)
        {
            try
            {
                var involvedGroups = await _db.Post_GroupMembers.AsNoTracking()
                    .Where(s => s.IsActive && s.MemberId == UserId)
                    .Select(s => s.GroupId).ToListAsync();
                involvedGroups.Add(_db.Mem_Masters.Find(UserId).GroupId ?? 0);
                var listOfTimeLine = await _db.Post_Masters
                    .AsNoTracking()
                    .Where(x => x.GroupId == null || involvedGroups.Any(s => s == x.GroupId))
                    .OrderByDescending(x => x.CDate)
                    .Include(x=>x.OpendBy)
                    .Include(x=>x.Followers)
                    .Include(x => x.Likes)
                    .Include(x => x.PostImages)
                    .Include(x => x.Comments)
                        .ThenInclude(x => x.Views)
                    .Select(n => _mapper.Map<FeedDto>(n, opt => opt.Items.Add("UserId",UserId) ))
                    .Skip(offset).Take(5)
                    .ToListAsync();
                return listOfTimeLine;
            }
            catch (Exception e)
            {
                throw e;
            }

           
        }

        
    }
}