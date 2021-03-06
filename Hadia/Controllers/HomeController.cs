﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hadia.Models;
using Hadia.Data;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Serialization.Json;
using System.Text;
using Hadia.Concrete;
using Hadia.Helper;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hadia.Controllers
{
    /*
     * This is a Controller for Test and development
     */
    [Authorize(AuthenticationSchemes=CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly HadiaContext _db;
        private AuthService _auth;
        private static readonly HttpClient client = new HttpClient();
        public HomeController(HadiaContext db)
        {
            this._db = db;
            _auth = new AuthService(db);
        }
        public IActionResult Index()
        {
            if (!_db.Mem_Masters.Any())
            {
                _auth.CreatePasswordHash("123456",out var passwordHash,out var passwordSalt);
                var newMem = new Mem_Master
                {
                    AdNo = "111",
                    Name = "Jane Doe",
                    DateOfBirth = DateTime.Now,
                    IsGroupAdmin = false,
                    IsVarified = false,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    CountryCode = "91",
                    Phone = "9969969961",
                    CDate = DateTime.Now,
                    Email = "janedoe"
                    

                };
                _db.Mem_Masters.Add(newMem);
                _db.SaveChanges();
            }
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> About()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<CountryRest>));
            //ViewData["Message"] = User.FindFirst(ClaimTypes.Name).Value;
            var streamTask = client.GetStreamAsync("https://restcountries.eu/rest/v2/all");
            var repositories = serializer.ReadObject(await streamTask) as List<CountryRest>;
            var list = repositories.Select(x => new Mem_CountryCode
            {
                CountryCode = x.callingCodes.Length > 0 ? x.callingCodes[0] : "",
                CDate = DateTime.UtcNow,
                CountryName = x.name,
                TimeZone = x.timezones.Length > 0 ? x.timezones[0].Replace("UTC",String.Empty) : "",
                Lat = x.latlng.Length > 0 ? x.latlng[0] : 0,
                Long = x.latlng.Length > 1 ? x.latlng[1] : 0

            }).ToList();
            await _db.Mem_CountryCodes.AddRangeAsync(list);
            await _db.SaveChangesAsync();
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Contact()
        {
            
            await _db.Mem_Masters.AddAsync(new Mem_Master
            {
                CDate = DateTime.Now
            });
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewData["Message"] = "Your contact page.";    
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
