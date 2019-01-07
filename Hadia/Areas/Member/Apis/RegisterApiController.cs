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
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Hadia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hadia.Areas.Member.Controllers
{

    //[Produces("application/json")]
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly HadiaContext _db;
        private  IMapper _mapper ;
        private AuthService _authServive ;

        public RegisterController(IMapper mapper,HadiaContext context)
        {
            _mapper = mapper;
            _db = context;
            
            _authServive = new AuthService(context);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<RegistrationResourseDto>> StepOne()
        {
            var listOfUgiColleges = await _db.Mem_UgColleges.Select(x => _mapper.Map<UgCollageDto>(x)).ToListAsync();
            var listOfBatch = await _db.Post_GroupMasters.Where(x=>x.Type == GroupType.Batch )
            .Select(x=> new BatchDto {
                Id = x.Id,
                Name = x.GroupName
            }).ToListAsync();
            var maritalStatus =Enum.GetValues(typeof(MaritalStatus))
               .Cast<MaritalStatus>()
               .Select(t => new EnumValuesDto
               {
                   Id = ((int)t),
                   Name = Enum.GetName(typeof(MaritalStatus),t)
               });
            var listOfStates = await _db.Mem_StateMasters.Select(x =>_mapper.Map<StateDto>(x)).ToListAsync();
            var listOfChapters = await _db.Post_GroupMasters.Where(x => x.Type == GroupType.Chapter)
                                      .Select(x=> new ChapterDto
                                      {
                                          Id = x.Id,
                                          Name = x.GroupName
                                      }).ToListAsync();
            var newResorce = new RegistrationResourseDto {
                Batches =listOfBatch,
                UgCollages = listOfUgiColleges,
                States = listOfStates,
                MaritalStatus = maritalStatus.ToList(),
                Chapters = listOfChapters
            };
            
            return Ok(newResorce);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> StepOne(RegistrationDto registration)
        {

                if(await _authServive.UserExists(registration.Email))
                    throw new Exception("Email Id exist.",new Exception("Email Id is unique."));
                    
                byte[] passwordHash, passwordSalt;
                var model = _mapper.Map<Mem_Master>(registration);

                model.IsVarified =false;
                model.IsGroupAdmin = false;
                _authServive.CreatePasswordHash(registration.Password,out passwordHash,out passwordSalt);
                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;
                model.CDate = DateTime.Now;
                await _db.Mem_Masters.AddAsync(model);
                await _db.Post_GroupMembers.AddAsync(new Post_GroupMember
                {
                    GroupId = registration.ChapterId,
                    CDate = DateTime.Now,
                    IsActive = true,
                    MemberId = model.Id,
                    IsGroupAdmin = false,
                    AddedBy = model.Id,
                    
                });
                try
                {
                    await _db.SaveChangesAsync();
                    return Ok(new RegistrationResultDto {
                        UserId = model.Id,
                        Key=1
                    });
                }
                catch (System.Exception ex)
                {
                     throw ex;
                }

        }


        [HttpGet]
        public async Task<ActionResult<RegisterEductionResourceDto>> steptwo()
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
                throw ex;
            }


            return Ok("Success");
        }

        [HttpGet]
        public async Task<ActionResult<RegisterJobResourceDto>> stepthree()
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

        [Obsolete]
        [HttpPost]
        public  async Task<IActionResult> stepthree(List<JobdetailDto> jobs)
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

        [HttpGet]
        public async Task<ActionResult<RegistrationFamilyResourceDto>> stepfour()
         {
             var listOfSpouseEducations = await _db.Mem_SpouseEducationMasters
                                     .Select(x=> _mapper.Map<SpouseEducationDto>(x)).ToListAsync();
                                     return Ok(new RegistrationFamilyResourceDto {
                                            SpouseEducations = listOfSpouseEducations
                                     });
             
         }

        [HttpPost]
        public async Task<IActionResult> stepfour(RegistrationFamilyDto family)
        {
            try
            {
            
             var userFromDb = await _db.Mem_Masters.FindAsync(family.UserId);
             userFromDb.SpouseName = family.SpouseName;
             userFromDb.SpouseEducationId = family.SpouseEducationId;
             if(family.SpouseAge != null)
             userFromDb.SpouseAge  = DateTime.Now.AddYears(-family.SpouseAge??0);
             if (family.Children.Any())
             {
                    var kids = _mapper.Map<IEnumerable<Mem_Kid>>(family.Children);
                    foreach (var kid in kids)
                    {
                        kid.CDate = DateTime.Now;
                        kid.MemberId = family.UserId;
                    }
                  await _db.Mem_Kids.AddRangeAsync(kids);
            }
            _db.Update(userFromDb);
            await  _db.SaveChangesAsync();
            return Ok(new {success ="sucess"});
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }


        [HttpGet]
        public async Task<IActionResult> Districts(int id)
        {
            var districts = await _db.Mem_DistrictMasters
                .Where(x => x.StateId == id)
                .Select(dist => new DistrictDto
                {
                    Id = dist.Id,
                    Name = dist.DistrictName
                }).ToListAsync();

           return Ok(districts);
        }

        // private  int ProfilePercentage(int userid)
        // {
        //     var education = new List<ProfileCompletation>(){
        //         new ProfileCompletation{
        //             Field ="
        //             "
        //         }
        //     }
        // }
       
        
    }
}