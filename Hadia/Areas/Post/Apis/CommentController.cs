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
    public class CommentController : BaseApiController
    {
        private HadiaContext _db;
        private Mapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;


        public CommentController(HadiaContext db, Mapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostCommentDto commentDto)
        {
            await _db.Post_Comments.AddAsync(new Post_Comment
            {
                Comment = commentDto.Comment,
                PostId = commentDto.MasterId,
                MemberId = UserId,
                Type = commentDto.Type
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReplay(CreatePostCommentDto commentDto)
        {
            await _db.Post_Comments.AddAsync(new Post_Comment
            {
                Comment = commentDto.Comment,
                MasterId = commentDto.MasterId,
                MemberId = UserId,
                Type = commentDto.Type
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            var listOfComments = await _db.Post_Comments
                                       .Include(x=>x.Createdby)
                                       .Include(x => x.PostComments)
                                            .ThenInclude(x=>x.Createdby)
                                       .Where(x => x.PostId == id).ToListAsync();
            return Ok(listOfComments);
        }
    }
}