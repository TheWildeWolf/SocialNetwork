using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hadia.Core;
using Hadia.Data;
using Hadia.Models.DomainModels;

namespace Hadia.Concrete
{
    public class ResetPassword:IResetPassword
    {
        private readonly HadiaContext _db;
        private readonly char[] _punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();
        public ResetPassword(HadiaContext db)
        {
            _db = db;
        }
        public async Task<bool> ResetAsync (Mem_Master user,string password)
        {
            var key = Generate(8, 2);

            return false;
        }

        private void SendMail(string mailId)
        {
            SmtpClient client = new SmtpClient("mysmtpserver")
            {
                UseDefaultCredentials = false, Credentials = new NetworkCredential("username", "password")
            };
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("whoever@me.com");
            mailMessage.To.Add(mailId);
            mailMessage.Body = "body";
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
        }

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
    }
}
