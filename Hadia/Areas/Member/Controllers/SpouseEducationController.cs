using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    [Area("Member")]
    public class SpouseEducationController : Controller
    {
        private HadiaContext _db;
        public SpouseEducationController(HadiaContext context)
        {
            _db = context;
        }

        public async Task< IActionResult> Index()
        {
            var ListOfSpouseEducation=await _db.Mem_SpouseEducationMasters
               .ToListAsync();
            return View(ListOfSpouseEducation);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Mem_SpouseEducationMaster SpouseEducationMaster)
        {
            if(_db.Mem_SpouseEducationMasters.Any(X=>X.QualificationName==SpouseEducationMaster.QualificationName))
            {
                ModelState.AddModelError("QualificationName", "Qualification Name Already Exist");
            }
            if(ModelState.IsValid)
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _db.Mem_SpouseEducationMasters.AddAsync(SpouseEducationMaster);
                SpouseEducationMaster.CLogin = userId;
                SpouseEducationMaster.CDate = DateTime.Now;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(SpouseEducationMaster);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int ?id)
        {
            if (id == null)
                return NotFound();
            var EditData = await _db.Mem_SpouseEducationMasters.FindAsync(id);
            if (EditData == null)
                return NotFound();
                await  _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id,Mem_SpouseEducationMaster SpouseEducationMaster)
        {
            if (id != SpouseEducationMaster.Id)
                return NotFound();
            if(_db.Mem_SpouseEducationMasters.Any(x=>x.QualificationName==SpouseEducationMaster.QualificationName&&x.Id!=SpouseEducationMaster.Id))
            {
                ModelState.AddModelError("QualificationName", "Qualification Name Already Exist");
            }
            if(ModelState.IsValid)
            {

                _db.Update(SpouseEducationMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SpouseEducationMaster);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_SpouseEducationMasters.FindAsync(id);
            _db.Mem_SpouseEducationMasters.Remove(DelData);
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
            var ListSpouseQualification = await _db.Mem_SpouseEducationMasters.FindAsync(id);
            return View(ListSpouseQualification);
        }
    }

   
}