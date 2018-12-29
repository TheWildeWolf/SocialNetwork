using System;
using System.Linq;
using System.Security.Claims;
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
    public class PostController : BaseApiController
    {
        private HadiaContext _db;
        private IMapper _mapper;

        public PostController(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PostCategoryDto>> Category()
        {
            var listOfData = await _db.Post_Categories
                .Select(x=> _mapper.Map<PostCategoryDto>(x)).ToListAsync();
            return Ok(listOfData);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto postDto)
        {
            
            var userid = Convert.ToInt32(User.FindFirst(x => x.ValueType == ClaimTypes.NameIdentifier).Value);
            await _db.Post_Masters.AddAsync(new Post_Master
            {
                CDate = DateTime.Now,
                CategoryId = postDto.CategoryId,
                OpnedId = userid
                

            });
            return Ok();
        }
    }
}