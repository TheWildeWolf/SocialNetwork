using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
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

    public class JobDetailController : BaseApiController
    {
        private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public JobDetailController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(JobdetailDto jobDetail)
        {
            await _db.Mem_WorkDetails.AddAsync(new Mem_WorkDetail
            {
                CDate = DateTime.UtcNow,
                CompanyName = jobDetail.CompanyName,
                CountryId = jobDetail.CountryId,
                DateForm = jobDetail.DateForm,
                DateUpto = jobDetail.DateUpto,
                Location = jobDetail.Location,
                JobCategoryId = jobDetail.JobCategoryId,
                MemberId = jobDetail.UserId,
                JobTitle = jobDetail.JobTitle
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(JobdetailDto jobDetail)
        {
           var jobtodb = _mapper.Map<Mem_WorkDetail>(jobDetail);
            jobtodb.CDate = DateTime.UtcNow;
            jobtodb.MemberId = UserId;
            await _db.Mem_WorkDetails.AddAsync(jobtodb);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(JobdetailDto jobDetail)
        {
            var jobIndb = _db.Mem_WorkDetails.Find(jobDetail.Id);
            if (jobIndb == null || jobIndb.MemberId != UserId)
                return NotFound();
            var editedJob = _mapper.Map(jobDetail,jobIndb);
            _db.Update(editedJob);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(JobdetailDto jobDetail)
        {
            var jobIndb = _db.Mem_WorkDetails.Find(jobDetail.Id);
            if (jobIndb == null || jobIndb.MemberId != UserId)
                return NotFound();
            _db.Entry(jobIndb).State = EntityState.Deleted;
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message
                });
            }
        }

    }
}