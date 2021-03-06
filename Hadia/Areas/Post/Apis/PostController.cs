﻿using System;
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
        public PostController(HadiaContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public IActionResult View(int id)
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
                    .AsNoTracking()
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
                    .AsNoTracking()
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

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewComments(int id)
        {
            var data = await _db.Post_Comments
                .AsNoTracking()
                .Include(x => x.Views)
                .Where(x => x.PostId == id).SelectMany(x=> x.Views ).ToListAsync();
            data = data.Select(x =>
            {
                x.IsRead = true;
                return x;
            }).ToList();

            _db.UpdateRange(data);
            await _db.SaveChangesAsync();
            return Ok();

        }

    }
}