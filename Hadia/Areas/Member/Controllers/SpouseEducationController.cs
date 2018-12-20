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
    public class SpouseEducationController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public SpouseEducationController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
            var ListOfSpouseEducation=await _db.Mem_SpouseEducationMasters
              .Select(x => _mapper.Map<SpouseEducationMasterViewModel>(x)).ToListAsync();

            return View(ListOfSpouseEducation);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(SpouseEducationMasterViewModel SpouseEducationMaster,string btnSave)
        {
            if(_db.Mem_SpouseEducationMasters.Any(X=>X.QualificationName==SpouseEducationMaster.QualificationName))
            {
                ModelState.AddModelError("QualificationName", "Qualification Name Already Exist");
            }
            if(ModelState.IsValid)
            {

                var newSpouseEduMaster = _mapper.Map<Mem_SpouseEducationMaster>(SpouseEducationMaster);
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newSpouseEduMaster.CLogin = userId;
                newSpouseEduMaster.CDate = DateTime.Now;
                await _db.Mem_SpouseEducationMasters.AddAsync(newSpouseEduMaster);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("Spouse Education Created!");
                if (btnSave == "Save")
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                return View("Create");
            }
            return View(SpouseEducationMaster);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int ?id)
        {
            if (id == null)
                return NotFound();
           
            var EditData = await _db.Mem_SpouseEducationMasters
               .Select(x => _mapper.Map<SpouseEducationMasterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
                await  _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id,SpouseEducationMasterViewModel SpouseEducationMaster)
        {
            if (id != SpouseEducationMaster.Id)
                return NotFound();
            if(_db.Mem_SpouseEducationMasters.Any(x=>x.QualificationName==SpouseEducationMaster.QualificationName&&x.Id!=SpouseEducationMaster.Id))
            {
                ModelState.AddModelError("QualificationName", "Qualification Name Already Exist");
            }
            if(ModelState.IsValid)
            {

                var dataInDb = _db.Mem_SpouseEducationMasters.Find(id);
                var editMaster = _mapper.Map(SpouseEducationMaster, dataInDb);
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
            var ListSpouseQualification = await _db.Mem_SpouseEducationMasters
               .Select(x => _mapper.Map<SpouseEducationMasterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            return View(ListSpouseQualification);
        }
    }

   
}