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
    public class ProjectController : BaseApiController
    {
         private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public ProjectController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(ProjectworkDto project)
        {
            await _db.Mem_ProjectWorks.AddAsync(new Mem_ProjectWork
            {
                CDate = DateTime.UtcNow,
                Description = project.Description,
                MemberId = project.UserId,
                ProjectTitle = project.ProjectTitle
            });
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
        public async Task<IActionResult> Create(ProjectworkDto project)
        {
            var projectTodb = _mapper.Map<Mem_ProjectWork>(project);
            projectTodb.CDate = DateTime.UtcNow;
            projectTodb.MemberId = UserId;
            await _db.Mem_ProjectWorks.AddAsync(projectTodb);
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
        public async Task<IActionResult> Update(ProjectworkDto project)
        {
            var projectInDb = _db.Mem_ProjectWorks.Find(project.Id);
            if (projectInDb == null || projectInDb.MemberId != UserId)
                return NotFound();
            var projectEdited = _mapper.Map(project,projectInDb);
            _db.Update(projectEdited);
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
        public async Task<IActionResult> Delete(ProjectworkDto project)
        {
            var projectInDb = _db.Mem_ProjectWorks.Find(project.Id);
            if (projectInDb == null || projectInDb.MemberId != UserId)
                return NotFound();
            _db.Entry(projectInDb).State = EntityState.Deleted ;
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