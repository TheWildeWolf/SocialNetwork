using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        public PostController(HadiaContext db, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Like(int id)
        {
            if (!_db.Post_Likes.Any(x => x.PostId == id && x.MemberId == id))
            {
                await _db.Post_Likes.AddAsync(new Post_Like
                {
                    CDate = DateTime.Now,
                    Like = true,
                    PostId = id,
                    MemberId = UserId
                });
            }
            else
            {
                var edit = await _db.Post_Likes
                    .SingleOrDefaultAsync(x => x.PostId == id && x.MemberId == UserId);
                edit.Like = !edit.Like;
                _db.Update(edit);
            }
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

    }
}