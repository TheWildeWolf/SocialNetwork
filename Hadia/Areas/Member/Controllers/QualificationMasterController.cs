using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    [Area("Member")]
    public class QualificationMasterController : Controller
    {
        private HadiaContext _db;

        public QualificationMasterController(HadiaContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            var listOfQualifications =await _db.Mem_EducationalQualifications
                .ToListAsync();
            
            return View(listOfQualifications);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Mem_EducationalQualificationMaster qualificationMaster)
        {
           if(ModelState.IsValid)
            {
                await _db.Mem_EducationalQualifications.AddAsync(qualificationMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(qualificationMaster);
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var EditData =await _db.Mem_EducationalQualifications.FindAsync(id);
            _db.SaveChanges();
            return View(EditData);


        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_EducationalQualifications.FindAsync(id);
            _db.Mem_EducationalQualifications.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}