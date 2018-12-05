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
        public async Task< IActionResult> Edit(int ?id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var EditData =await _db.Mem_EducationalQualifications.FindAsync(id);
            if(EditData==null)
            {
                return NotFound();
            }
            _db.SaveChanges();
            return View(EditData);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mem_EducationalQualificationMaster qualificationMaster)
        {
            if(ModelState.IsValid)
            {


            }
            return View();
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
            var ListEmployee = await _db.Mem_EducationalQualifications.FindAsync(id);
            return View(ListEmployee);
        }
    }
}