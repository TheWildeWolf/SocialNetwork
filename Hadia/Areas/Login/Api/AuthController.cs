using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hadia.Controllers;
using Hadia.Core;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hadia.Areas.Login.Api
{

    public class LoginController : BaseApiController
    {
        private HadiaContext _db;
        private IConfiguration _config;
        private IAuthService _authServive;
        public LoginController(
            HadiaContext context,
            IConfiguration config,
            IAuthService authServive)
        {
            _db = context;
            _config = config;
            _authServive = authServive;
        }

        [HttpGet]
        public IActionResult Get()
        {
            /*
             * test method to check token auth
             */
            //await _db.Mem_Masters.AddAsync(new Mem_Master
            //{
            //    CDate = DateTime.Now
            //});
            //try
            //{
            //    await _db.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoginSuccessDto>> Login(LoginDto logindata)
        {
            if(!await _authServive.UserExists(logindata.Username))
                return Unauthorized(new { error = "User not exist!" });

            var user = await _authServive.Login(username: logindata.Username, password: logindata.Password);

            if (user == null)
                return Unauthorized(new {error = "Username or Password is incorrect" });

            if (!user.IsVarified)
                return Unauthorized(new { error = "Your Account Not Yet Approved, Please Contact Admin Panel For More Info.." });
            var ugCollege = await _db.Mem_UgColleges.FirstOrDefaultAsync(x => x.Id == user.UgCollageId);
            var key = GenerateId();
            var loginSuccess = new LoginSuccessDto
            {
                Id = user.Id,
                Name = user.Name,
                Token = GenerateJwtToken(user, key),
                UgCollege = ugCollege.UgCollegeName,
                BatchId = user.GroupId,
                ChapterId = (_db.Post_GroupMembers.FirstOrDefault(x=> x.MemberId == user.Id && x.IsActive && x.GroupMaster.Type == GroupType.Chapter)??new Post_GroupMember()).GroupId,
                Photo = (_db.Mem_Photos.FirstOrDefault(s => s.MemberId == user.Id && s.IsActive)?? new Mem_Photo()).Image

            };
            await _db.Sett_LoginLogs.AddAsync(new Sett_LoginLog
            {
                MemberId = user.Id,
                LoginTime = DateTime.UtcNow,
                KeyValue = key
            });
            await _db.Sett_DeviceInfoLogs.AddAsync(new Sett_DeviceInfoLog
            {
                MemberId = user.Id,
                CDate = DateTime.UtcNow,
                DeviceKey = logindata.DeviceKey

            });
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(loginSuccess);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto change)
        {
            var user = await _db.Mem_Masters.FindAsync(UserId);

            if (await _authServive.Update(user, change.OldPassword, change.NewPassword))
                return Ok();

            return Unauthorized();
        }
        private string GenerateJwtToken(Mem_Master user,string uid)
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, uid)
            };

            // var roles = await _userManager.GetRolesAsync(user);

            // foreach (var role in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, role));
            // }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}