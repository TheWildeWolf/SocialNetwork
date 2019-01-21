using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Login.Api
{

    [AllowAnonymous]
    public class ResetController : BaseApiController
    {
        private HadiaContext _db;
        private IHostingEnvironment _hostingEnvironment;
        public ResetController(HadiaContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Check(string email)
        {
            if(await _db.Mem_Masters.AnyAsync(x=> x.Email == email))
            {
                var user = await _db.Mem_Masters
                                .AsNoTracking()
                                .SingleOrDefaultAsync(x => x.Email == email);
                var key  = Generate(15, 2);
                var dlt =await _db.Sett_Resets.Where(x => x.MemberId == user.Id).ToListAsync();
                _db.Sett_Resets.RemoveRange(dlt);
                await _db.Sett_Resets.AddAsync(new Sett_Reset
                {
                    CDate = DateTime.UtcNow,
                    ExpireDate = DateTime.UtcNow.AddHours(1),
                    Key = key,
                    MemberId = user.Id
                });
                try
                {
                    await _db.SaveChangesAsync();
                    var urlKey = EncryptionHelper.Encrypt(key + "_" + user.Id);
                    SendMail(user.Email, urlKey);
                    return Ok();
                }
                catch (Exception e)
                {
                    throw e;
                }


            }
            return Ok();
        }
        private readonly char[] _punctuations = "!@#$%^&*()_-+=[{]};:>|.?".ToCharArray();

        private string Generate(int length, int numberOfNonAlphanumericCharacters)
        {
            if (length < 1 || length > 128)
            {
                throw new ArgumentException(nameof(length));
            }

            if (numberOfNonAlphanumericCharacters > length || numberOfNonAlphanumericCharacters < 0)
            {
                throw new ArgumentException(nameof(numberOfNonAlphanumericCharacters));
            }

            using (var rng = RandomNumberGenerator.Create())
            {
                var byteBuffer = new byte[length];

                rng.GetBytes(byteBuffer);

                var count = 0;
                var characterBuffer = new char[length];

                for (var iter = 0; iter < length; iter++)
                {
                    var i = byteBuffer[iter] % 87;

                    if (i < 10)
                    {
                        characterBuffer[iter] = (char)('0' + i);
                    }
                    else if (i < 36)
                    {
                        characterBuffer[iter] = (char)('A' + i - 10);
                    }
                    else if (i < 62)
                    {
                        characterBuffer[iter] = (char)('a' + i - 36);
                    }
                    else
                    {
                        characterBuffer[iter] = _punctuations[i - 62];
                        count++;
                    }
                }

                if (count >= numberOfNonAlphanumericCharacters)
                {
                    return new string(characterBuffer);
                }

                int j;
                var rand = new Random();

                for (j = 0; j < numberOfNonAlphanumericCharacters - count; j++)
                {
                    int k;
                    do
                    {
                        k = rand.Next(0, length);
                    }
                    while (!char.IsLetterOrDigit(characterBuffer[k]));

                    characterBuffer[k] = _punctuations[rand.Next(0, _punctuations.Length)];
                }

                return new string(characterBuffer);
            }
        }

        private string GetBody(string key)
        {

            var htmlbody = System.IO.File.ReadAllText(Path.Combine(_hostingEnvironment.WebRootPath, "File.html"));
           return htmlbody.Replace("[@url]", "http://alumni.hadia.in/Auth/Verify?key=" + key);
        }

        private void SendMail(string mailId,string key)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("hadiaalumni@gmail.com", "hadia@123"),
                EnableSsl = true
            };
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("hadiaalumni@gmail.com");
            mailMessage.To.Add(mailId);
            mailMessage.Body = GetBody(key);
            mailMessage.Priority = MailPriority.High;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Hadia Alumni Reset Password";
            client.Send(mailMessage);
        }
    }
}