using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChildrenController : BaseApiController
    {
        private readonly HadiaContext _db;
        private IMapper _mapper;
        public ChildrenController(IMapper mapper, HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(KidsDto kid)
        {
            var dbkid = _mapper.Map<Mem_Kid>(kid);
            dbkid.MemberId = UserId;
            dbkid.CDate = DateTime.UtcNow;
            await _db.Mem_Kids.AddRangeAsync(dbkid);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    success = "Success"
                });
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(KidsDto kid)
        {
            var kidInDb = _db.Mem_Kids.Find(kid.Id);
            if (kidInDb == null || kidInDb.MemberId != UserId)
                return NotFound();
            var editedKid = _mapper.Map(kid,kidInDb);
            _db.Update(editedKid);
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(KidsDto kid)
        {
            var kidInDb = _db.Mem_Kids.Find(kid.Id);
            if (kidInDb == null || kidInDb.MemberId != UserId)
                return NotFound();
            _db.Entry(kidInDb).State = EntityState.Deleted;
            try
            {
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    success = "Success"
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}