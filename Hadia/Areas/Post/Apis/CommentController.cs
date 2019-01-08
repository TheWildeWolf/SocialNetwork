using System;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    public class CommentController : BaseApiController
    {
        private HadiaContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IMapper _mapper;


        public CommentController(HadiaContext db, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePostCommentDto commentDto)
        {

            var folderName = DateTime.Now.ToString("yyyy-MM-dd");
            var imageUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Images/");
            var voiceUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Voice/");
            switch (commentDto.Type)
            {
                case CommentType.Image:
                    
                    if (commentDto.File != null)
                    {
                        if (!Directory.Exists(Path.Combine(imageUploadPath, folderName)))
                            Directory.CreateDirectory(Path.Combine(imageUploadPath, folderName));

                            if (commentDto.File.Length > 0)
                            {
                                string extension = Path.GetExtension(commentDto.File.FileName);
                                var filePath = FileDetail(imageUploadPath, Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + UserId + extension));
                                using (var fileStream = new FileStream(filePath.FilePath, FileMode.Create))
                                {
                                    await commentDto.File.CopyToAsync(fileStream);
                                    commentDto.Comment = filePath.FileName;
                                }
                            }
                        
                    }
                    break;
                case CommentType.Voice:
                    if (commentDto.File != null)
                    {
                        if (!Directory.Exists(Path.Combine(voiceUploadPath, folderName)))
                            Directory.CreateDirectory(Path.Combine(voiceUploadPath, folderName));

                        var voicePath = FileDetail(voiceUploadPath, Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + UserId + "_voice.m4a"));
                        using (var fileStream = new FileStream(voicePath.FilePath, FileMode.Create))
                        {
                            await commentDto.File.CopyToAsync(fileStream);
                            commentDto.Comment = voicePath.FileName;
                        }
                    }
                    break;

            }

            var postMaster = await _db.Post_Masters
                .Include(x=>x.PostImages)
                .SingleOrDefaultAsync(x=>x.Id ==commentDto.MasterId);
           
            var newComment = new Post_Comment
            {
                Comment = commentDto.Comment,
                PostId = commentDto.MasterId,
                MemberId = UserId,
                Type = commentDto.Type,
                Date =  DateTime.UtcNow,
                
            };
            newComment.Views =new List<Post_CommentView>();
            var commentView = new Post_CommentView
            {
                CDate = DateTime.UtcNow,
                IsRead = false,
                MemberId = postMaster.OpnedId,
            };
            newComment.Views.Add(commentView);
            await _db.Post_Comments.AddAsync(newComment);
           
            try
            {
                await _db.SaveChangesAsync();
                var main =await _db.Post_Comments
                    .Include(x => x.Createdby)
                        .ThenInclude(x => x.Photos)
                    .SingleOrDefaultAsync(x => x.Id == newComment.Id);
                var toDto = _mapper.Map<CommentViewDto>(main);
                return Ok(toDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReplay([FromForm]CreatePostCommentDto commentDto)
        {

            var folderName = DateTime.Now.ToString("yyyy-MM-dd");
            var imageUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Images/");
            var voiceUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/Voice/");
            switch (commentDto.Type)
            {
                case CommentType.Image:

                    if (commentDto.File != null)
                    {
                        if (!Directory.Exists(Path.Combine(imageUploadPath, folderName)))
                            Directory.CreateDirectory(Path.Combine(imageUploadPath, folderName));

                        if (commentDto.File.Length > 0)
                        {
                            string extension = Path.GetExtension(commentDto.File.FileName);
                            var filePath = FileDetail(imageUploadPath, Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + UserId + extension));
                            using (var fileStream = new FileStream(filePath.FilePath, FileMode.Create))
                            {
                                await commentDto.File.CopyToAsync(fileStream);
                                commentDto.Comment = filePath.FileName;
                            }
                        }

                    }
                    break;
                case CommentType.Voice:
                    if (commentDto.File != null)
                    {
                        if (!Directory.Exists(Path.Combine(voiceUploadPath, folderName)))
                            Directory.CreateDirectory(Path.Combine(voiceUploadPath, folderName));

                        var voicePath = FileDetail(voiceUploadPath, Path.Combine(folderName, DateTime.Now.ToFileTime() + "_" + UserId + "_voice.m4a"));
                        using (var fileStream = new FileStream(voicePath.FilePath, FileMode.Create))
                        {
                            await commentDto.File.CopyToAsync(fileStream);
                            commentDto.Comment = voicePath.FileName;
                        }
                    }
                    break;

            }
            
            await _db.Post_Comments.AddAsync(new Post_Comment
            {
                Comment = commentDto.Comment,
                MasterId = commentDto.MasterId,
                MemberId = UserId,
                Type = commentDto.Type,
                Date = DateTime.UtcNow
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

        [HttpGet("/api/comments/{id}")]
        public async Task<IActionResult> All(int id)
        {
            var listOfComments = await _db.Post_Comments
                                       .Include(x=>x.Createdby)
                                            .ThenInclude(x=>x.Photos) 
                                       .Include(x => x.PostComments)
                                            .ThenInclude(x=>x.Createdby)
                                       .Where(x => x.PostId == id)
                                            .Select(x=> _mapper.Map<CommentViewDto>(x))
                                       .ToListAsync();
            return Ok(listOfComments);
        }

        private FileDetail FileDetail(string path, string fileName)
        {
            return new FileDetail
            {
                FilePath = Path.Combine(path, fileName),
                FileName = fileName.Replace("\\", "/")
            };
        }
    }
}