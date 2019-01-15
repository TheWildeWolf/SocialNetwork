using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Login.Controllers
{
    [Area("Login")]
    public class ChangePasswordController : Controller
    {
        private HadiaContext _db;

        public ChangePasswordController(HadiaContext db)
        {
            _db = db;
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
                        return View();
                    }
                }
                return View("Error");

            }
            catch (Exception e)
            {
               return View("Error");
            }

        }
    }
}