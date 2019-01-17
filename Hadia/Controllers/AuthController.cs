using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hadia.Concrete;
using Hadia.Core;
using Hadia.Data;
using Hadia.Helper;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private IAuthService _auth;
        private readonly HadiaContext _db;
        public AuthController( HadiaContext context, IAuthService auth)
        {
            _db = context;
            _auth = auth;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logindata)
        {
            var user = await _auth.Login(logindata.Username, logindata.Password);
            if (user == null)
            {
                ModelState.AddModelError("Password","Password or username incorrect.");
                return View(logindata);
            }

            if (!user.IsGroupAdmin)
            {
                ModelState.AddModelError("Password", "You Don't Have access to this area!");
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                // Refreshing the authentication session should be allowed.
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(4),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.
                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. Required when setting the 
                // ExpireTimeSpan option of CookieAuthenticationOptions 
                // set with AddCookie. Also required when setting 
                // ExpiresUtc.
                IssuedUtc = DateTimeOffset.UtcNow
                // The time at which the authentication ticket was issued.
                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return RedirectToAction("Index", "MemberList", new {area = "Member"});
        }

       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Settings(AuthSettingsViewModel authSettings)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user =await _db.Mem_Masters.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            if (!authSettings.NewPassword.Equals(authSettings.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword","Not equal");
                TempData["message"] = Notifications.ErrorNotify("Please check Confirm password.");
                return View(authSettings);
            }
            if(await _auth.Update(user, authSettings.CurrentPassword, authSettings.NewPassword))
            {
                TempData["message"] = Notifications.SuccessNotify("Password Changed");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            if (!_db.Mem_Masters.Any())
            {
                //byte[] passhash;
                //byte[] passsalt;

                //_auth.CreatePasswordHash("hadia@123", out passhash, out passsalt);
                //var newMem = new Mem_Master
                //{
                //    AdNo = "000",
                //    Name = "Administrator",
                //    DateOfBirth = DateTime.UtcNow,
                //    IsGroupAdmin = false,
                //    IsVarified = false,
                //    PasswordSalt = passsalt,
                //    PasswordHash = passhash,
                //    CountryCode = "91",
                //    Phone = "001",
                //    CDate = DateTime.UtcNow,
                //    Email = "Admin"


                //};
                //await _db.Mem_Masters.AddAsync(newMem);
                //await _db.SaveChangesAsync();
            }

            return RedirectToAction("Login");
        }


    }
}