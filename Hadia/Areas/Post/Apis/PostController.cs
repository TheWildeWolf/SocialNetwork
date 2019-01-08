using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
   
    public class PostController : BaseApiController
    {
        private readonly HadiaContext _db;
        private readonly IMapper _mapper;
        public PostController(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Like(int id)
        {
            bool isLike;
            if (!_db.Post_Likes.Any(x => x.PostId == id && x.MemberId == UserId))
            {
                await _db.Post_Likes.AddAsync(new Post_Like
                {
                    CDate = DateTime.Now,
                    Like = true,
                    PostId = id,
                    MemberId = UserId
                });
                isLike = true;
            }
            else
            {
                var edit = await _db.Post_Likes
                    .SingleOrDefaultAsync(x => x.PostId == id && x.MemberId == UserId);
                isLike =edit.Like = !edit.Like;
                _db.Update(edit);
            }
            try
            {
                await _db.SaveChangesAsync();
                var count = await _db.Post_Likes.CountAsync(x => x.PostId == id && x.Like);
                return Ok(new LikeResultDto
                {
                    Count = count.ToString(),
                    IsLike = isLike
                });

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Follow(int id)
        {
            bool isFollowed;
            if (!_db.Post_Followers.Any(x => x.PostId == id && x.MemberId == UserId))
            {
                await _db.Post_Followers.AddAsync(new Post_Follow
                {
                    Follow = true,
                    MemberId = UserId,
                    PostId = id
                });
                isFollowed = true;
            }
            else
            {
                var edit = await _db.Post_Followers
                    .SingleOrDefaultAsync(x => x.PostId == id && x.MemberId == UserId);
                isFollowed = edit.Follow = !edit.Follow;
                _db.Update(edit);
            }
            try
            {
                await _db.SaveChangesAsync();
                return Ok(isFollowed);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}