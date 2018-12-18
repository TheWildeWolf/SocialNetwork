using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Helper;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class JobCategoryController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;

        public JobCategoryController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var listOfJobs = await _db.Mem_JobCategoryMasters
                .Select(x => _mapper.Map<JobCategoryViewModel>(x)).ToListAsync();
            return View(listOfJobs);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobCategoryViewModel jobCategory)
        {
            if (await _db.Mem_JobCategoryMasters.AnyAsync(x => x.CategoryName == jobCategory.CategoryName))
            {
                ModelState.AddModelError("CategoryName", "Category Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var newJobCatgryr = _mapper.Map<Mem_JobCategoryMaster>(jobCategory);
                var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newJobCatgryr.CLogin = userid;
                newJobCatgryr.CDate = DateTime.Now;
                await _db.Mem_JobCategoryMasters.AddAsync(newJobCatgryr);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("Category Created!");
                return RedirectToAction("Index");
            }
            return View(jobCategory);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var EditData = await _db.Mem_JobCategoryMasters
                .Select(x => _mapper.Map<JobCategoryViewModel>(x))
                .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
            {
                return NotFound();
            }

            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobCategoryViewModel jobCategory)
        {
            if (id != jobCategory.Id)
            {
                return NotFound();
            }
            if (_db.Mem_JobCategoryMasters.Any(x => x.CategoryName == jobCategory.CategoryName && x.Id != jobCategory.Id))
            {
                ModelState.AddModelError("CategoryName", "Category Name Already Exist");

            }
            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_JobCategoryMasters.Find(id);
                    var editMaster = _mapper.Map(jobCategory, dataInDb);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View(jobCategory);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_JobCategoryMasters.FindAsync(id);
            _db.Mem_JobCategoryMasters.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
      
    }
}