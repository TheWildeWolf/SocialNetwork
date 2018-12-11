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
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class CountryCodeController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public CountryCodeController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfCountry = await _db.Mem_CountryCodes
                 .Select(x => _mapper.Map<CountryCodeViewModel>(x)).ToListAsync();
            return View(ListOfCountry);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CountryCodeViewModel countryCode)
        {
            if (_db.Mem_CountryCodes.Any(X => X.CountryName == countryCode.CountryName))
            {
                ModelState.AddModelError("CountryName", "Country Name Already Exist");
            }
            if (ModelState.IsValid)
            {

                var newCountry = _mapper.Map<Mem_CountryCode>(countryCode);
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                newCountry.CDate = DateTime.Now;
                await _db.Mem_CountryCodes.AddAsync(newCountry);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(countryCode);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var EditData = await _db.Mem_CountryCodes
               .Select(x => _mapper.Map<CountryCodeViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
            await _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CountryCodeViewModel countryCode)
        {
            if (id != countryCode.Id)
                return NotFound();
            if (_db.Mem_CountryCodes.Any(x => x.CountryName == countryCode.CountryName && x.Id != countryCode.Id))
            {
                ModelState.AddModelError("CountryName", "Country Name Already Exist");
            }
            if (ModelState.IsValid)
            {

                var dataInDb = _db.Mem_CountryCodes.Find(id);
                var editMaster = _mapper.Map(countryCode, dataInDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryCode);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_CountryCodes.FindAsync(id);
            _db.Mem_CountryCodes.Remove(DelData);
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
            var ListCountry= await _db.Mem_CountryCodes
               .Select(x => _mapper.Map<CountryCodeViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            return View(ListCountry);
        }

    }
}