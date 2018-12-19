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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{

    public class QualificationMasterController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;

        public QualificationMasterController(HadiaContext context,IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listOfQualifications =await _db.Mem_EducationalQualifications
                .Select(x=> _mapper.Map<EducationalQualificationMasterViewModel>(x) ).ToListAsync();
            return View(listOfQualifications);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EducationalQualificationMasterViewModel qualificationMaster)
        {
            if (await _db.Mem_EducationalQualifications.AnyAsync(x => x.DegreeName == qualificationMaster.DegreeName))
            {
                ModelState.AddModelError("DegreeName","Degree Name Already Exist");               
            }
           if(ModelState.IsValid)
            {
                var newQualificationMaster = _mapper.Map<Mem_EducationalQualificationMaster>(qualificationMaster);
                var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newQualificationMaster.CLogin = userid;
                newQualificationMaster.CDate = DateTime.Now;
                await _db.Mem_EducationalQualifications.AddAsync(newQualificationMaster);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("Qualification Created!");
                return RedirectToAction("Index");
            }
            return View(qualificationMaster);
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int ?id)
        {
            
            if(id==null)
            {
                return NotFound();
            }
            var EditData =await _db.Mem_EducationalQualifications
                .Select(x => _mapper.Map<EducationalQualificationMasterViewModel>(x))
                .FirstOrDefaultAsync(x=>x.Id== id);
            if(EditData==null)
            {
                return NotFound();
            }

            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EducationalQualificationMasterViewModel qualificationMaster)
        {
            if(id!=qualificationMaster.Id)
            {
                return NotFound();
            }
            if (_db.Mem_EducationalQualifications.Any(x => x.DegreeName == qualificationMaster.DegreeName&&x.Id!= qualificationMaster.Id))
            {
                ModelState.AddModelError("DegreeName", "Degree Name Already Exist");

            }
            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_EducationalQualifications.Find(id);
                    var editMaster = _mapper.Map(qualificationMaster, dataInDb);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException)
                {
                    throw;
                }
              
            }
            return View(qualificationMaster);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_EducationalQualifications.FindAsync(id);
            _db.Mem_EducationalQualifications.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<ActionResult>Details(int?id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ListQualification = await _db.Mem_EducationalQualifications
                  .Select(x => _mapper.Map<EducationalQualificationMasterViewModel>(x))
                  .FirstOrDefaultAsync(x => x.Id == id);
            return View(ListQualification);
        }
    }
}