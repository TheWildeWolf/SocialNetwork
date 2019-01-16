using System;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Apis
{

    //[Produces("application/json")]
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EducationQualificationController : BaseApiController
    {
        private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public EducationQualificationController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(QualificationDto qualification)
        {
            await _db.Mem_EducationDetails.AddAsync(new Mem_EducationDetail
            {
                CDate =DateTime.UtcNow,
                EducationQualificationId = qualification.QualificationId,
                PassoutYear = new DateTime(qualification.PassoutYear, 1, 1),
                MemberId = qualification.UserId,
                Specialization = qualification.Specialization,
                UniversityId = qualification.UniversityId,
                PhdTopic = qualification.Topic
            });
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new { success = "Success" });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationDetailEditDto qualification)
        {
            var qualificationtoDb = _mapper.Map<Mem_EducationDetail>(qualification);
            qualificationtoDb.CDate = DateTime.UtcNow;
            qualificationtoDb.MemberId = UserId;
            await _db.Mem_EducationDetails.AddAsync(qualificationtoDb);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new { success = "Success" });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(EducationDetailEditDto qualification)
        {
            try
            {
                var qualificationInDb = _db.Mem_EducationDetails.Find(qualification.Id);
            if (qualificationInDb == null || qualificationInDb.MemberId != UserId)
                return NotFound();
            var qualificationEdited = _mapper.Map(qualification,qualificationInDb);
            _db.Update(qualificationEdited);

                await _db.SaveChangesAsync();
                return Ok(new { success = "Success" });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EducationDetailEditDto qualification)
        {
            var qualificationInDb = _db.Mem_EducationDetails.Find(qualification.Id);
            if (qualificationInDb == null || qualificationInDb.MemberId != UserId)
                return NotFound();
            _db.Entry(qualificationInDb).State = EntityState.Deleted;
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new { success = "Success" });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}