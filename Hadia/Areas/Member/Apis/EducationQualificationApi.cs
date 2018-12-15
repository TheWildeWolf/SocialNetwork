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
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EducationQualificationController : ControllerBase
    {
        private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public EducationQualificationController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(QualificationDto qualification)
        {
            await _db.Mem_EducationDetails.AddAsync(new Mem_EducationDetail{
                //CDate =DateTime.Now,
                EducationQualificationId =qualification.QualificationId,
                PassoutYear = new DateTime(qualification.PassoutYear,1,1),
                MemberId =qualification.UserId,
                Specialization =qualification.Specialization,
                UniversityId =qualification.UniversityId,
                PhdTopic = qualification.Topic 

            });
            
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new {success="Success"});
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            
        }

    }
}