using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    public class BatchController : BaseApiController
    {
        private readonly HadiaContext _db;

        public BatchController(HadiaContext db)
        {
            _db = db;
        }

        [HttpGet("/api/Batch")]
        public async Task<IActionResult> Batch()
        {
            var listOfBatch = await _db.Post_GroupMasters
                .AsNoTracking()
                .Where(x => x.Type == GroupType.Batch)
                .Select(x => new BatchDto
                {
                    Id = x.Id,
                    Name = x.GroupName
                }).ToListAsync();

            return Ok(listOfBatch);
        }

        [HttpGet("/api/Chapter")]
        public async Task<IActionResult> Chapter()
        {
            var listOfChapters = await _db.Post_GroupMasters.Where(x => x.Type == GroupType.Chapter)
                .Select(x => new BatchDto
                {
                    Id = x.Id,
                    Name = x.GroupName
                }).ToListAsync();

            return Ok(listOfChapters);
        }
    }
}