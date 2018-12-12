using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hadia.Areas.Member.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobDetailController : ControllerBase
    {
        private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public JobDetailController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobdetailDto jobDetail)
        {
            await _db.Mem_WorkDetails.AddAsync(new Mem_WorkDetail{
                CDate = DateTime.Now,
                CompanyName =jobDetail.CompanyName,
                CountryId =jobDetail.CountryId,
                DateForm =jobDetail.DateForm,
                DateUpto =jobDetail.DateUpto,
                Location = jobDetail.Location,
                JobCategoryId = jobDetail.JobCategoryId,
                MemberId = jobDetail.UserId,
                JobTitle= jobDetail.JobTitle
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new {
                    Success="Success"
                });
            }
            catch (System.Exception ex)
            {
                return Ok(new {
                    error =ex.Message
                });
            }
            
        }

    }
}