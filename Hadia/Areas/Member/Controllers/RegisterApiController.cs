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

    //[Authorize]
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
            _db.Mem_UgColleges.Select(x => _mapper.Map<UgCollageDto>(x)).ToListAsync();

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

        [HttpGet]
        public async Task<IActionResult> steptwo()
        {
            //Add Multiple Education Details for an Member get method
            var educationQualifications = await _db.Mem_EducationalQualifications
                                            .Select(x=> _mapper.Map<EducationQualificationDto>(x)).ToListAsync();
            var universities            = await _db.Mem_UniversityMasters.Select(x=> _mapper.Map<UniversityDto>(x))
                                            .ToListAsync();
            
            var registrationEducationResource = new RegisterEductionResourceDto {
                EducationQualifications =educationQualifications,
                Universities = universities
            };

            return Ok(registrationEducationResource);
            
        }

        [HttpPost]
        public async Task<IActionResult> steptwo(EducationRegisterDto registerEducation)
        {
            int userId = 1; //change this to JWT token claim
            foreach(var edu in registerEducation.Qualifications)
            {
               await _db.Mem_EducationDetails.AddAsync(new Mem_EducationDetail{
                   CDate =DateTime.Now,
                   EducationQualificationId =edu.QualificationId,
                   MemberId = userId,
                   PassoutYear = new DateTime(edu.PassoutYear,1,1),
                   PhdTopic = edu.Topic,
                   UniversityId =edu.UniversityId,
                   Specialization = edu.Specialization,
                   
               });
            }

            foreach (var project in registerEducation.Projects)
            {
                await _db.Mem_ProjectWorks.AddAsync( new Mem_ProjectWork{
                    MemberId = userId,
                    Description = project.Description,
                    ProjectTitle = project.ProjectTitle
                });
            }

            try
            {
            await _db.SaveChangesAsync();    
            }
            catch (System.Exception ex)
            {
                
                return Ok(ex);
            }
            

            return Ok("Success");
        }

        [HttpGet]
        public async Task<IActionResult> stepthree()
        {
            //jobDetail
            var listOfCountries = await _db.Mem_CountryCodes
                                .Select(x=> _mapper.Map<CountryDto>(x))
                                .ToListAsync();
            var listOfJobs = await _db.Mem_JobCategoryMasters
                            .Select(x=>_mapper.Map<JobCategoryDto>(x)).ToListAsync();
            var jobResource = new RegisterJobResourceDto {
                Countries =listOfCountries,
                JobCategories = listOfJobs
            };
            return Ok(jobResource);
        }
        
        [HttpPost]
         public async Task<IActionResult> stepthree(List<JobdetailDto> jobs)
         {
             var userId = 1;
             var joblis = _mapper.Map<IEnumerable<Mem_WorkDetail>>(jobs);
              foreach (var job in joblis)
             {
                job.CDate = DateTime.Now;
                job.MemberId = userId;
             }
             await _db.AddRangeAsync(joblis);
             await _db.SaveChangesAsync();
             return Ok();
             
         }
    }
}