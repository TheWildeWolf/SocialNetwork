using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class UniversityMasterController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public UniversityMasterController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfCountry = await _db.Mem_UniversityMasters
                .Include(x => x.Country)
                .Select(x => _mapper.Map<UniversityMasterViewModel>(x)).ToListAsync();
            return View(ListOfCountry);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Countryselctlist = new SelectList(_db.Mem_CountryCodes.ToList(), "Id", "CountryName");
            var UniversityViewModel = new UniversityMasterViewModel
            {
                CountryList = Countryselctlist
            };
            return View(UniversityViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UniversityMasterViewModel universityMaster)
        {
            if (await _db.Mem_UniversityMasters.AnyAsync(x => x.UniversityName == universityMaster.UniversityName))
            {
                ModelState.AddModelError("UniversityName", "University name already exist");

            }

            if (ModelState.IsValid)
            {


                var newUniversity = _mapper.Map<Mem_UniversityMaster>(universityMaster);
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newUniversity.CLogin = userId;
                newUniversity.CDate = DateTime.Now;
                await _db.Mem_UniversityMasters.AddAsync(newUniversity);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            universityMaster.CountryList = new SelectList(_db.Mem_CountryCodes.ToList(), "Id", "CountryName", universityMaster.CountryId);
            return View(universityMaster);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var EditData = await _db.Mem_UniversityMasters.Select(x => _mapper.Map<UniversityMasterViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            var Countryselctlist = new SelectList(_db.Mem_CountryCodes.ToList(), "Id", "CountryName", EditData.CountryId);
            EditData.CountryList = Countryselctlist;
            if (EditData == null)
                return NotFound();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UniversityMasterViewModel universityMaster)
        {

            if (id != universityMaster.Id)
            {
                return NotFound();
            }
            if (_db.Mem_UniversityMasters.Any(x => x.UniversityName == universityMaster.UniversityName && x.Id != universityMaster.Id))
            {
                ModelState.AddModelError("UniversityName", "University Name Already Exist");

            }
            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_UniversityMasters.Find(id);
                    var editMaster = _mapper.Map(universityMaster, dataInDb);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View(universityMaster);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_UniversityMasters.FindAsync(id);
            _db.Mem_UniversityMasters.Remove(DelData);
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
            var ListUniversity = await _db.Mem_UniversityMasters.Include(x => x.Country)
                  .Select(x => _mapper.Map<UniversityMasterViewModel>(x))
                  .FirstOrDefaultAsync(x => x.Id == id);
            var stateselctlist = new SelectList(_db.Mem_CountryCodes.Where(S => S.Id == ListUniversity.CountryId).ToList(), "Id", "CountryName");
            return View(ListUniversity);
        }

    }
}