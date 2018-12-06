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
    public class StateMasterController : Controller
    {
        private HadiaContext _db;
        public StateMasterController(HadiaContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfStates = await _db.Mem_StateMasters
               .ToListAsync();
            return View(ListOfStates);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Mem_StateMaster StateMaster)
        {
            if (_db.Mem_StateMasters.Any(X => X.StateName == StateMaster.StateName))
            {
                ModelState.AddModelError("StateName", "State Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _db.Mem_StateMasters.AddAsync(StateMaster);
                StateMaster.CLogin = userId;
                StateMaster.CDate = DateTime.Now;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(StateMaster);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var EditData = await _db.Mem_StateMasters.FindAsync(id);
            if (EditData == null)
                return NotFound();
            await _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mem_StateMaster StateMaster)
        {
            if (id != StateMaster.Id)
                return NotFound();
            if (_db.Mem_StateMasters.Any(x => x.StateName == StateMaster.StateName && x.Id != StateMaster.Id))
            {
                ModelState.AddModelError("StateName", "State Name Already Exist");
            }
            if (ModelState.IsValid)
            {

                _db.Update(StateMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(StateMaster);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_StateMasters.FindAsync(id);
            _db.Mem_StateMasters.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
       
}