using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Controllers;
using Hadia.Core;
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
        private INotification _notification;

        public TimelineController(
            HadiaContext db,
            IMapper mapper, 
            IHostingEnvironment hostingEnvironment,
            INotification notification)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _notification = notification;
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

            var newPost = new Post_Master
            {
                CDate = DateTime.UtcNow,
                CategoryId = postDto.CategoryId,
                OpnedId = userid,
                Voice = voicePath.FileName,
                PostImages = postedImages.Any() ? postedImages : null,
                Topic = postDto.Topic,
                Status = PostStatus.Active,
                GroupId = postDto.GroupId,
                DonationType = postDto.DonationType ?? DonationType.None
            };
            // validate if any of the data is available before saving. -- by jafer
            if(string.IsNullOrEmpty(newPost.Topic) && (newPost.PostImages == null || !newPost.PostImages.Any()) && string.IsNullOrEmpty(newPost.Voice))
            {
                throw new Exception("Somthing went wrong"); 
            }
            await _db.Post_Masters.AddAsync(newPost);
            try
            {
                await _db.SaveChangesAsync();
                try
                {
                    var returnData = await _db.Post_Masters
                        .AsNoTracking()
                        .Include(x => x.PostImages)
                        .Where(x => x.Id == newPost.Id)
                        .Select(x => _mapper.Map<DataPostDto>(x))
                        .Take(1)
                        .SingleOrDefaultAsync();
                    return Ok(returnData);
                }
                finally
                {
                    string body = string.Empty;
                    if (string.IsNullOrEmpty(newPost.Topic) && (newPost.PostImages != null && newPost.PostImages.Any()) && string.IsNullOrEmpty(newPost.Voice))
                    {
                        body = "Image";
                    }
                    else if (string.IsNullOrEmpty(newPost.Topic) && (newPost.PostImages == null || !newPost.PostImages.Any()) && !string.IsNullOrEmpty(newPost.Voice))
                    {
                        body = "Voice";
                    }
                    else
                    {
                        body = newPost.Topic;
                    }

                    await _notification.Notify(UserId, UserName, body, postDto.GroupId ?? 0);
                }

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
                .AsNoTracking()
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