using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hadia.Areas.Member.Apis
{
    public class ProfileController : BaseApiController
    {
        private readonly HadiaContext _db;
        private IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProfileController(HadiaContext db, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileDetailViewDto>> View()
        {
            var memberDetails = await _db.Mem_Masters.AsNoTracking()
                .Include(x => x.UgCollege)
                .Include(x => x.Photos)
                .Include(x => x.MainGroup)
                .Include(x=>x.Projects)
                .Include(x => x.MembershipInGroups)
                    .ThenInclude(n => n.GroupMaster)
                .Include(x => x.District)
                .Include(y => y.Kids)
                .Include(y => y.SpouseEducation)
                .Include(x => x.EducationDetails)
                    .ThenInclude(x => x.Qualification)
                .Include(x => x.EducationDetails)
                    .ThenInclude(x => x.University)
                .Include(x => x.WorkDetails)
                    .ThenInclude(x => x.Country)
                .Include(x => x.WorkDetails)
                    .ThenInclude(x => x.CategoryMaster)
                .Select(x => _mapper.Map<ProfileDetailViewDto>(x))
                .FirstOrDefaultAsync(x => x.Id == UserId);

            return Ok(memberDetails);
        }
        [HttpPost]
        public async Task<IActionResult> AddPhoto([FromForm]ProfilePicDto profilepic)
        {
            if (profilepic.Image != null )
            {
                        string extension = Path.GetExtension(profilepic.Image.FileName);
                        var imageName = DateTime.Now.ToFileTime() + "_" + UserId + extension;
                        var dir = Path.Combine(_hostingEnvironment.WebRootPath, "Media/ProfileImage/");
                        var filePath = Path.Combine(dir, imageName); 
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await profilepic.Image.CopyToAsync(fileStream);
                            var photos = await _db.Mem_Photos.Where(x => x.MemberId == UserId).ToListAsync();
                            foreach (var memPhoto in photos)
                            {
                                memPhoto.IsActive = false;
                            }
                            await _db.Mem_Photos.AddAsync(new Mem_Photo
                            {
                                Image = imageName,
                                CDate = DateTime.UtcNow,
                                IsActive = true,
                                MemberId = UserId
                            });
                            _db.UpdateRange(photos);
                        }
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                   
                    throw e;
                }
              
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var listOfImages = await _db.Mem_Photos
                .Where(x => x.MemberId == UserId)
                .Select(x => _mapper.Map<MemberPhotoDto>(x)).ToListAsync();
            return Ok(listOfImages);
        }

        [HttpGet]
        public async Task<IActionResult> SetActive(int id)
        {
            var listOfImages = await _db.Mem_Photos.Where(x => x.MemberId == UserId).ToListAsync();
            foreach (var photo in listOfImages)
             photo.IsActive = photo.Id == id;

            _db.UpdateRange(listOfImages);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ProfilePic()
        {
            var url = await _db.Mem_Photos.SingleOrDefaultAsync(x => x.MemberId == UserId && x.IsActive);

            return Ok("/Profile/"+url.Image);
        }
    }
}