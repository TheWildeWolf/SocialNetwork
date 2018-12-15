using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Member.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Controllers
{
    public class ChapterController : BasePostController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        private IHostingEnvironment _hostingEnvironment;
        public ChapterController(HadiaContext context, IMapper mapper,IHostingEnvironment hostingEnvironment)
        {
            _db = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfChapter = await _db.Post_GroupMasters.Where(x=>x.Type==GroupType.Chapter)
                 .Select(x => _mapper.Map<ChapterViewModel>(x)).ToListAsync();
            return View(ListOfChapter);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task UploadImageAsync(IFormFile ImageFile,string FileName)
        {
           
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "ChapterImages");
            if (ImageFile.Length > 0)
            {   
                var filePath = Path.Combine(uploads, FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(ChapterViewModel chapterView)
        {
            if (await _db.Post_GroupMasters.AnyAsync(x => x.GroupName == chapterView.GroupName &&  x.Type == GroupType.Chapter))
            {
                ModelState.AddModelError("GroupName", "Chapter Name Already Exist");

            }
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (ModelState.IsValid)
            {
                    
                var imageFileName = DateTime.Now.ToFileTime().ToString();
                await UploadImageAsync(chapterView.ImageFile, imageFileName + ".jpg");
                var newChapter = _mapper.Map<Post_GroupMaster>(chapterView);
                newChapter.Type = GroupType.Chapter;
                newChapter.OpenOrClosed = GroupPrivacy.Closed;
                newChapter.GroupImage = imageFileName;
                newChapter.CLogin = userId;
                newChapter.CDate = DateTime.Now;
                await _db.Post_GroupMasters.AddAsync(newChapter);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chapterView);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var EditData = await _db.Post_GroupMasters
               .Select(x => _mapper.Map<ChapterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
            EditData.ImageLocation = GetImage(EditData.ChapterImage);
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ChapterViewModel chapterView)
        {
            if (id != chapterView.Id)
                return NotFound();
            if (_db.Post_GroupMasters.Any(x => x.GroupName == chapterView.GroupName && x.Id != chapterView.Id))
            {
                ModelState.AddModelError("GroupName", "Chapter Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var dataInDb = _db.Post_GroupMasters.Find(id);
                var editMaster = _mapper.Map(chapterView, dataInDb);
                if (chapterView.ImageFile != null)
                {
                    if (string.IsNullOrEmpty(editMaster.GroupImage))
                        editMaster.GroupImage = DateTime.Now.ToFileTime().ToString();

                    await UploadImageAsync(chapterView.ImageFile, editMaster.GroupImage+".jpg");
                }
                //else
                //{
                //    editMaster.GroupImage = dataInDb.GroupImage;
                //}
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chapterView);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Post_GroupMasters.FindAsync(id);
            _db.Post_GroupMasters.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ListChapter = await _db.Post_GroupMasters
               .Select(x => _mapper.Map<ChapterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            ListChapter.ImageLocation = GetImage(ListChapter.ChapterImage);
            //Path.Combine(_hostingEnvironment.WebRootPath, "ChapterImages\\"+ListChapter.GroupImage+".jpg");
            return View(ListChapter);
        }

        private string GetImage(string image) => $"/ChapterImages/{image}.jpg";


    }
}