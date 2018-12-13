using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Member.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Controllers
{
    public class ChapterController : BasePostController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public ChapterController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfBatch = await _db.Post_GroupMasters
                 .Select(x => _mapper.Map<BatchViewModel>(x)).ToListAsync();
            return View(ListOfBatch);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var Batch = new BatchViewModel();
            return View(Batch);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BatchViewModel batchView)
        {
            if (await _db.Post_GroupMasters.AnyAsync(x => x.GroupName == batchView.GroupName))
            {
                ModelState.AddModelError("GroupName", "Chapter Name Already Exist");

            }

            if (ModelState.IsValid)
            {


                var newBatch = _mapper.Map<Post_GroupMaster>(batchView);
                newBatch.Type = Models.DomainModels.GroupType.Batch;
                newBatch.OpenOrClosed = Models.DomainModels.GroupPrivacy.Closed;
                newBatch.GroupImage = "";
                newBatch.FormedOn = null;
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newBatch.CLogin = userId;
                newBatch.CDate = DateTime.Now;
                await _db.Post_GroupMasters.AddAsync(newBatch);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(batchView);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var EditData = await _db.Post_GroupMasters
               .Select(x => _mapper.Map<BatchViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
            await _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BatchViewModel batchView)
        {
            if (id != batchView.Id)
                return NotFound();
            if (_db.Post_GroupMasters.Any(x => x.GroupName == batchView.GroupName && x.Id != batchView.Id))
            {
                ModelState.AddModelError("GroupName", "Batch Name Already Exist");
            }
            if (ModelState.IsValid)
            {

                var dataInDb = _db.Post_GroupMasters.Find(id);
                var editMaster = _mapper.Map(batchView, dataInDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batchView);

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
            var ListBatch = await _db.Post_GroupMasters
               .Select(x => _mapper.Map<BatchViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            return View(ListBatch);
        }
    }
}