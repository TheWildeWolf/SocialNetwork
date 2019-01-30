using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Areas.Login.Models;
using Hadia.Core;
using Hadia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Login.Controllers
{
    [Area("Login")]
    public class ChangePasswordController : Controller
    {
        private HadiaContext _db;
        private IAuthService _auth;
        public ChangePasswordController(HadiaContext db, IAuthService auth)
        {
            _db = db;
            _auth = auth;
        }
        [HttpGet("/Auth/Verify")]
        public async Task<IActionResult> Change(string key)
        {
            try
            {
                var decrypted = EncryptionHelper.Decrypt(key);
                var index = decrypted.LastIndexOf('_');
                var passkey = decrypted.Substring(0, index);
                var userId = Convert.ToInt32(decrypted.Substring(index + 1, decrypted.Length - (index+1)));
                var data =await _db.Sett_Resets.SingleOrDefaultAsync(x => x.MemberId == userId && x.Key == passkey);
                if (data != null)
                {
                    if (DateTime.UtcNow < data.ExpireDate)
                    {
                        return View("Change", new PasswordViewModel
                        {
                           Key = key
                        });
                    }
                }
                return View("Error");

            }
            catch (Exception)
            {
               return View("Error");
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost("/Auth/Reset")]
        public async Task<IActionResult> ChangePassword(string key,PasswordViewModel passwordView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var decrypted = EncryptionHelper.Decrypt(key);
                    var index = decrypted.LastIndexOf('_');
                    var passkey = decrypted.Substring(0, index);
                    var userId = Convert.ToInt32(decrypted.Substring(index + 1, decrypted.Length - (index + 1)));
                    var data = await _db.Sett_Resets.SingleOrDefaultAsync(x => x.MemberId == userId && x.Key == passkey);
                    if (data != null)
                    {
                        if (DateTime.UtcNow < data.ExpireDate)
                        {
                            if (passwordView.NewPassword.Equals(passwordView.ConfirmPassword))
                            {
                                var member = await _db.Mem_Masters.FindAsync(userId);
                                 if(await _auth.ResetPassword(member,passwordView.NewPassword))
                                 {
                                     data.ExpireDate = DateTime.UtcNow;
                                     _db.Update(data);
                                     await _db.SaveChangesAsync();
                                     return View("Success");
                                 }
                            }
                        }
                    }
                    return View("Error");

                }
                catch (Exception e)
                {
                    return View("Error");
                }
            }

            return View("Change", passwordView);
        }
    }
}