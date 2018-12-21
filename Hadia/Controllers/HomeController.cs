using System;
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
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hadia.Controllers
{
    /*
     * This is a Democontroller for Test and development
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
                byte[] passhash;
                byte[] passsalt;

                _auth.CreatePasswordHash("123456",out passhash,out passsalt);
                var newMem = new Mem_Master
                {
                    AdNo = "111",
                    Name = "Jane Doe",
                    DateOfBirth = DateTime.Now,
                    IsGroupAdmin = false,
                    IsVarified = false,
                    PasswordSalt = passsalt,
                    PasswordHash = passhash,
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
        public async Task<IActionResult> About()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<CountryApi>));
            ViewData["Message"] = User.FindFirst(ClaimTypes.Name).Value;
            var streamTask = client.GetStreamAsync("https://restcountries.eu/rest/v2/all");
            var repositories = serializer.ReadObject(await streamTask) as List<CountryApi>;
            //var list = repositories.Select(x=> new Mem_CountryCode
            //{
            //    CountryCode = x.callingCodes.to
            //}).ToList()
            //_db.Mem_CountryCodes.AddRangeAsync()
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            throw  new Exception("super cool");
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
