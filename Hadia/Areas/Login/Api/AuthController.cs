﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hadia.Areas.Login.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private HadiaContext _db;
        private IConfiguration _config;
        private AuthService _authServive;
        public AuthController(HadiaContext context,IConfiguration config)
        {
            _db = context;
            _config = config;
            _authServive =new AuthService(context);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            /*
             * test method to check token auth
             */
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

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto logindata)
        {
           var user = await _authServive.Login(username: logindata.Username, password: logindata.Password);
            if (user == null)
                return Unauthorized(new {error = "Username or Password is incorrect"});

            var loginSuccess = new LoginSuccessDto
            {
                Id = user.Id,
                Name = user.Name,
                Token = GenerateJwtToken(user)
            };
            await _db.Sett_LoginLogs.AddAsync(new Sett_LoginLog
            {
                MemberId = user.Id,
                LoginTime = DateTime.Now,
                KeyValue = ""
            });
            await _db.Sett_DeviceInfoLogs.AddAsync(new Sett_DeviceInfoLog
            {
                MemberId = user.Id,
                CDate = DateTime.Now,
                DeviceKey = logindata.DeviceKey,

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

        private string GenerateJwtToken(Mem_Master user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
            };

            // var roles = await _userManager.GetRolesAsync(user);

            // foreach (var role in roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, role));
            // }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}