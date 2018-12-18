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
    public class UgCollegeController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public UgCollegeController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var listOfUgColleges = await _db.Mem_UgColleges
                .Select(x => _mapper.Map<UgCollegesViewModel>(x)).ToListAsync();
            return View(listOfUgColleges);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UgCollegesViewModel UgColleges)
        {
            if (await _db.Mem_UgColleges.AnyAsync(x => x.UgCollegeName == UgColleges.UgCollegeName))
            {
                ModelState.AddModelError("UgCollegeName", "Ug College Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var newUgCollegeName = _mapper.Map<Mem_UgColleges>(UgColleges);
                var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newUgCollegeName.CLogin = userid;
                newUgCollegeName.CDate = DateTime.Now;
                await _db.Mem_UgColleges.AddAsync(newUgCollegeName);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("Ug College Created!");
                return RedirectToAction("Index");
            }
            return View(UgColleges);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var EditData = await _db.Mem_UgColleges
                .Select(x => _mapper.Map<UgCollegesViewModel>(x))
                .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
            {
                return NotFound();
            }

            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UgCollegesViewModel UgColleges)
        {
            if (id != UgColleges.Id)
            {
                return NotFound();
            }
            if (_db.Mem_UgColleges.Any(x => x.UgCollegeName == UgColleges.UgCollegeName && x.Id != UgColleges.Id))
            {
                ModelState.AddModelError("UgCollegeName", "Ug College Name Already Exist");

            }
            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_UgColleges.Find(id);
                    var editMaster = _mapper.Map(UgColleges, dataInDb);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
               
            }
            return View(UgColleges);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_UgColleges.FindAsync(id);
            _db.Mem_UgColleges.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}