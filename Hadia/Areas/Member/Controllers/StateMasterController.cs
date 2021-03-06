﻿using System;
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
    public class StateMasterController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public StateMasterController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int? Page)
        {
            var ListOfStates = await _db.Mem_StateMasters.AsNoTracking()
                .Select(x=> _mapper.Map<StateMasterViewModel>(x))
                .OrderBy(x=>x.StateName)
               .ToListAsync();
            int i = 1;
            foreach(var item in ListOfStates)
            {
                item.Sn = i;
                i++;
            }
            var paginatedList = PaginatedList<StateMasterViewModel>.Create(ListOfStates, Page ?? 1, 100);
            return View(paginatedList);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StateMasterViewModel StateMaster,string btnSave)
        {
            if (_db.Mem_StateMasters.Any(X => X.StateName == StateMaster.StateName))
            {
                ModelState.AddModelError("StateName", "State Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var newStateMaster = _mapper.Map<Mem_StateMaster>(StateMaster);
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newStateMaster.CLogin = userId;
                newStateMaster.CDate = DateTime.Now;
                await _db.Mem_StateMasters.AddAsync(newStateMaster);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("State Created!");
                if (btnSave == "Save")
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                return View("Create");
            }
            return View(StateMaster);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var EditData = await _db.Mem_StateMasters
                .Select(x => _mapper.Map<StateMasterViewModel>(x))
                .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
           
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StateMasterViewModel StateMaster)
        {
            if (id != StateMaster.Id)
                return NotFound();
            if (_db.Mem_StateMasters.Any(x => x.StateName == StateMaster.StateName && x.Id != StateMaster.Id))
            {
                ModelState.AddModelError("StateName", "State Name Already Exist");
            }
            if (ModelState.IsValid)
            {
                var dataInDb = _db.Mem_StateMasters.Find(id);
                var editMaster = _mapper.Map(StateMaster, dataInDb);
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
}