using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class CountryController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public CountryController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD:Hadia/Areas/Member/Controllers/CountryCodeController.cs
            var ListOfCountry = await _db.Mem_CountryCodes
                 .Select(x => _mapper.Map<CountryViewModel>(x)).ToListAsync();
            return View(ListOfCountry);
=======
            var listOfCountry = await _db.Mem_CountryCodes
               .Select(x => _mapper.Map<CountryViewModel>(x)).ToListAsync();
            return View(listOfCountry);
>>>>>>> 5706c5295c6597f176433ec3495f65cbbfad3ae6:Hadia/Areas/Member/Controllers/CountryController.cs
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
<<<<<<< HEAD:Hadia/Areas/Member/Controllers/CountryCodeController.cs
        public async Task<IActionResult> Create(CountryViewModel countryCode)
=======
        public async Task<IActionResult> Create(CountryViewModel countryView)
>>>>>>> 5706c5295c6597f176433ec3495f65cbbfad3ae6:Hadia/Areas/Member/Controllers/CountryController.cs
        {
            if (await _db.Mem_CountryCodes.AnyAsync(x => x.CountryName == countryView.CountryName))
            {
                ModelState.AddModelError("CountryName", "Country Already Exist");
            }
            if (ModelState.IsValid)
            {
                var newCountry = _mapper.Map<Mem_CountryCode>(countryView);
                newCountry.CDate = DateTime.Now;
                await _db.Mem_CountryCodes.AddAsync(newCountry);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(countryView);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var EditData = await _db.Mem_CountryCodes
               .Select(x => _mapper.Map<CountryViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            if (EditData == null)
                return NotFound();
            await _db.SaveChangesAsync();
            return View(EditData);
        }
        [HttpPost]
<<<<<<< HEAD:Hadia/Areas/Member/Controllers/CountryCodeController.cs
        public async Task<IActionResult> Edit(int id, CountryViewModel countryCode)
=======
        public async Task<IActionResult> Edit(int id, CountryViewModel countryView)
>>>>>>> 5706c5295c6597f176433ec3495f65cbbfad3ae6:Hadia/Areas/Member/Controllers/CountryController.cs
        {
            if (id != countryView.Id)
                return NotFound();
            if (_db.Mem_CountryCodes.Any(x => x.CountryName == countryView.CountryName && x.Id != countryView.Id))
            {
                ModelState.AddModelError("CountryName", "Country Name Already Exist");
            }
            if (ModelState.IsValid)
            {

                var dataInDb = _db.Mem_CountryCodes.Find(id);
                var editMaster = _mapper.Map(countryView, dataInDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryView);

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
<<<<<<< HEAD:Hadia/Areas/Member/Controllers/CountryCodeController.cs
            var ListCountry= await _db.Mem_CountryCodes
=======
            var ListCountry = await _db.Mem_CountryCodes
>>>>>>> 5706c5295c6597f176433ec3495f65cbbfad3ae6:Hadia/Areas/Member/Controllers/CountryController.cs
               .Select(x => _mapper.Map<CountryViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            return View(ListCountry);
        }

    }
}
