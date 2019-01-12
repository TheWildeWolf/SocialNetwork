﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    public class TimelineController : BaseApiController
    {
        private readonly HadiaContext _db;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TimelineController(HadiaContext db, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult<PostCategoryDto>> Category()
        {
            var listOfData = await _db.Post_Categories
                .Select(x=> _mapper.Map<PostCategoryDto>(x)).ToListAsync();
            return Ok(listOfData);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePostDto postDto)
        {
            FileDetail voicePath = new FileDetail();
            var postedImages = new List<Post_Image>();
            var userid = UserId;
            var folderName = DateTime.Now.ToString("yyyy-MM-dd");
            var imageUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Images/");
            var voiceUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Voice/");
            if (postDto.PostImages != null && postDto.PostImages.Any())
            {
                if(!Directory.Exists(Path.Combine(imageUploadPath, folderName)))
                    Directory.CreateDirectory(Path.Combine(imageUploadPath, folderName));

                foreach (var item in postDto.PostImages)
                {
                    if (item.Length > 0)
                    {
                        string extension = Path.GetExtension(item.FileName);
                        var filePath = FileDetail(imageUploadPath,Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + userid + extension)); //Path.Combine(imageUploadPath, DateTime.Now.ToFileTime()+"_"+ userid + extension);
                        using (var fileStream = new FileStream(filePath.FilePath, FileMode.Create))
                        {
                            await item.CopyToAsync(fileStream);
                            postedImages.Add(new Post_Image
                             {
                                    CDate = DateTime.UtcNow,
                                    Image = filePath.FileName
                             });
                        }
                    }
                }
            }

            if (postDto.Voice != null)
            {
                if (!Directory.Exists(Path.Combine(voiceUploadPath, folderName)))
                    Directory.CreateDirectory(Path.Combine(voiceUploadPath, folderName));

                voicePath = FileDetail(voiceUploadPath,Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + userid + "_voice.m4a"));
                using (var fileStream = new FileStream(voicePath.FilePath, FileMode.Create))
                {
                    await postDto.Voice.CopyToAsync(fileStream);
                }
            }
            await _db.Post_Masters.AddAsync(new Post_Master
            {
                CDate = DateTime.UtcNow, 
                CategoryId = postDto.CategoryId,
                OpnedId = userid,
                Voice = voicePath.FileName,
                PostImages = postedImages,
                Topic = postDto.Topic,
                Status = PostStatus.Active,
                DonationType = postDto.DonationType ??  DonationType.None
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> MyTimeLine()
        {
            var listOfTimeLine = await _db.Post_Masters
                .Where(x => x.OpnedId == UserId)
                .Include(x => x.PostImages)
                .ToListAsync();
            return Ok(listOfTimeLine);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private FileDetail FileDetail(string path,string fileName)
        {
            return new FileDetail
            {
                FilePath = Path.Combine(path, fileName),
                FileName = fileName.Replace("\\","/")
            };
        }
    }
}