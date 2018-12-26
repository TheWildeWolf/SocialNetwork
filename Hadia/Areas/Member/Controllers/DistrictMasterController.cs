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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class DistrictMasterController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public DistrictMasterController(HadiaContext context,IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult>Index()
        {
            var ListOfDistrict = await _db.Mem_DistrictMasters
                .Include(x=>x.State)
                .Select(x => _mapper.Map<DistrictMasterViewModel>(x)).OrderBy(x=>x.DistrictName).ToListAsync();
            return View(ListOfDistrict);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            var stateselctlist = new SelectList(_db.Mem_StateMasters.ToList(), "Id", "StateName");
            var districtViewModel = new DistrictMasterViewModel
            {
                StateList = stateselctlist
            };
            return  View(districtViewModel);
        }
        [HttpPost]
        public async Task<IActionResult>Create(DistrictMasterViewModel districtMaster,string btnSave)
        {
            if(await _db.Mem_DistrictMasters.AnyAsync(x=>x.DistrictName==districtMaster.DistrictName))
            {
                ModelState.AddModelError("DistrictName", "District Name Already Exist");
            }
          
            if (ModelState.IsValid)
            {
                var newDistrict = _mapper.Map<Mem_DistrictMaster>(districtMaster);
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newDistrict.CLogin = userId;
                newDistrict.CDate = DateTime.Now;
                await _db.Mem_DistrictMasters.AddAsync(newDistrict);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("District Created!");
                if (btnSave == "Save")
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                var stateselctlist = new SelectList(_db.Mem_StateMasters.ToList(), "Id", "StateName");
                var districtViewModel = new DistrictMasterViewModel
                {
                    StateList = stateselctlist
                };
                return View(districtViewModel);

            }
            districtMaster.StateList = new SelectList(_db.Mem_StateMasters.ToList(), "Id", "StateName",districtMaster.StateId);
            return View(districtMaster);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ?id)
        {

            var EditData = await _db.Mem_DistrictMasters.Select(x => _mapper.Map<DistrictMasterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            var stateselctlist = new SelectList(_db.Mem_StateMasters.ToList(), "Id", "StateName", EditData.StateId);
            EditData.StateList = stateselctlist;
            if (EditData == null)
                return NotFound();
            return View(EditData);

           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,DistrictMasterViewModel districtMaster)
        {

            if (id != districtMaster.Id)
            {
                return NotFound();
            }
            if (_db.Mem_DistrictMasters.Any(x => x.DistrictName == districtMaster.DistrictName && x.Id != districtMaster.Id))
            {
                ModelState.AddModelError("DistrictName", "District Name Already Exist");

            }
            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_DistrictMasters.Find(id);
                    var editMaster = _mapper.Map(districtMaster, dataInDb);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View(districtMaster);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_DistrictMasters.FindAsync(id);
            _db.Mem_DistrictMasters.Remove(DelData);
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
            var ListDistricts = await _db.Mem_DistrictMasters.Include(x=>x.State)
                  .Select(x => _mapper.Map<DistrictMasterViewModel>(x))
                  .FirstOrDefaultAsync(x => x.Id == id);
            var stateselctlist = new SelectList(_db.Mem_StateMasters.Where(S=>S.Id==ListDistricts.StateId).ToList(), "Id", "StateName");


            return View(ListDistricts);
        }


    }
}