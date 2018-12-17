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
    public class ProjectController : ControllerBase
    {
         private readonly HadiaContext _db;
        private  IMapper _mapper ;
        public ProjectController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
         
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectworkDto project)
        {
            await _db.Mem_ProjectWorks.AddAsync(new Mem_ProjectWork {
                CDate =DateTime.Now,
                Description = project.Description,
                MemberId =project.UserId,
                ProjectTitle = project.ProjectTitle
            });
            try
            {
                await _db.SaveChangesAsync(); 
                return Ok(new {
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