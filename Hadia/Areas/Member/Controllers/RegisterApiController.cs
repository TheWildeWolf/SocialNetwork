using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private HadiaContext _db;
        private IMapper _mapper { get; }

        private AuthService _authServive ;
        public RegisterController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
            _authServive = new AuthService(context);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> StepOne()
        {
            var listOfUgiColleges = await 
            _db.
            Mem_UgColleges
            .Select(x => _mapper.Map<UgCollageDto>(x)).ToListAsync();

            var listOfBatch = await _db.Post_GroupMasters.Where(x=>x.Type == GroupType.Chapter )
            .Select(x=> new BatchDto {
                BatchId = x.Id,
                Name = x.GroupName
            }).ToListAsync();
            var maritalStatus =Enum.GetValues(typeof(MaritalStatus))
               .Cast<MaritalStatus>()
               .Select(t => new EnumValuesDto
               {
                   Value = ((int)t),
                   Name = Enum.GetName(typeof(MaritalStatus),t)
               });
            var listOfStates = await _db.Mem_StateMasters.Select(x =>_mapper.Map<StateDto>(x)).ToListAsync();
            var newResorce = new RegistrationResourseDto {
                Batches =listOfBatch,
                UgCollages = listOfUgiColleges,
                States = listOfStates,
                MaritalStatus = maritalStatus.ToList()
            };
            
            return Ok(newResorce);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> StepOne(RegistrationDto registration)
        {

                if(await _authServive.UserExists(registration.Email))
                    return BadRequest("Same Email Exist");
                
                byte[] passwordHash, passwordSalt;

                var model = _mapper.Map<Mem_Master>(registration);

                model.IsVarified =false;
                model.IsGroupAdmin = false;

                _authServive.CreatePasswordHash(registration.Password,out passwordHash,out passwordSalt);

                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;

                await _db.Mem_Masters.AddAsync(model);
                try
                {
                    await _db.SaveChangesAsync();
                    return Ok(model.Id);
                }
                catch (System.Exception ex)
                {
                    return  StatusCode(500,ex);
                }

        }


        

        
    }
}