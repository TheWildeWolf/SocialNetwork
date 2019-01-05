using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hadia.Helper;

namespace Hadia.Areas.Member.Controllers
{
    public class MemberListController : BaseMemberController
    {
        private readonly HadiaContext _db;
        private IMapper _mapper;
        public MemberListController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(MembersMasterViewModel memberMaster,int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(memberMaster.SortOrder) ? "name_desc" : "";
            var listOfMember = await _db.Mem_Masters.AsNoTracking()
                 .Include(x => x.UgCollege)
                 .Include(x => x.MembershipInGroups)
                 .ThenInclude(x => x.GroupMaster)
                 .Include(x => x.MainGroup)
                 .Select(x => _mapper.Map<MemberViewModel>(x)).ToListAsync();
            memberMaster.BatchList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Batch), "Id", "GroupName");
            if (memberMaster.BatchId != null)
            {
                listOfMember = listOfMember.Where(s => s.GroupId == memberMaster.BatchId).ToList();
            }
            memberMaster.ChapterList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Chapter).OrderBy(x=>x.GroupName), "Id", "GroupName");
            if(memberMaster.ChapterId != null)
            {
                listOfMember = listOfMember.Where(s => s.ChapterId== memberMaster.ChapterId).ToList();
            }
            if (!string.IsNullOrEmpty(memberMaster.Name))
                listOfMember = listOfMember.Where(n => (n.Name).Replace(" ", "").ToUpper().Contains(memberMaster.Name.Replace(" ", "").ToUpper())).ToList();
            switch (memberMaster.Approval)
            {
                case "Approved":
                    {
                        listOfMember = listOfMember.Where(s => s.IsVarified).ToList();
                        break;
                    }
                case "Not Approved":
                    {
                        listOfMember = listOfMember.Where(s => !s.IsVarified).ToList();
                        break;
                    }
                default:
                    {
                        listOfMember = listOfMember.ToList();
                        break;
                    }
            }

            int i = 1;
            foreach (var item in listOfMember)
            {
                item.Sn=i;
                i++;
            }
            memberMaster.Approval = memberMaster.Approval ?? "All";
            memberMaster.Members = PaginatedList<MemberViewModel>.Create(listOfMember, page ?? 1, 100);
            return View(memberMaster);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await GetDetail(id??0);
            return View(memberDetails);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_Masters.FindAsync(id);
            _db.Mem_Masters.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(int? id)
        {
            var data = await _db.Mem_Masters
                  .Include(x => x.MembershipInGroups)
                     .ThenInclude(n => n.GroupMaster)
                  .Include(X => X.UgCollege)
                     .FirstOrDefaultAsync(x => x.Id == id);
            
            var profile = _mapper.Map<ProfileEditViewModel>(data);
            profile.BatchList = 
                new SelectList(_db.Post_GroupMasters
                .Where(x=>x.Type ==GroupType.Batch).ToList(), "Id", "GroupName", profile.GroupId);

            profile.ChapterList =
                new SelectList(_db.Post_GroupMasters.Where(x=>x.Type==GroupType.Chapter)
                .ToList(), "Id", "GroupName", profile.ChapterId);
            profile.UgCollegeList =
                new SelectList(_db.Mem_UgColleges.ToList(),"Id", "UgCollegeName", profile.UgCollageId);
            return PartialView("_ProfileEdit", profile);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(int id,ProfileEditViewModel profileViewModel)
        {
            if (id != profileViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //View model to DomainModel
                    var dataInDb = _db.Mem_Masters.Find(id);
                    var editMaster = _mapper.Map(profileViewModel, dataInDb);
                    var chapter = _db.Post_GroupMembers
                    .Where(x => x.GroupMaster.Type == GroupType.Chapter && x.MemberId == id).OrderByDescending(x => x.GroupMaster.FormedOn)
                    .FirstOrDefault();
                     chapter.GroupId = profileViewModel.ChapterId;
               
                    _db.Update(editMaster);
                    _db.Update(chapter);
                    await _db.SaveChangesAsync();
                    var data = await GetDetail(id);
                    return PartialView("_ProfileView", data);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            profileViewModel.ChapterList =
             new SelectList(_db.Post_GroupMasters.Where(x => x.Type == GroupType.Chapter)
             .ToList(), "Id", "GroupName", profileViewModel.ChapterId);
            profileViewModel.UgCollegeList =
                new SelectList(_db.Mem_UgColleges.ToList(), "Id", "UgCollegeName", profileViewModel.UgCollageId);
            return PartialView("_ProfileEdit",profileViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditEducationalQualif(int? id)
        {
            var list = await _db.Mem_EducationDetails
                           .Include(n => n.Qualification)
                           .Include(n => n.University)
                .Where(x => x.MemberId == id)
                .Select(q => new EducationQualifictaionEditViewModel
                {
                    EducationQualificationId = q.EducationQualificationId,
                    PassoutYear =q.PassoutYear,
                    PhdTopic =q.PhdTopic,
                    QualificationName =q.Qualification.DegreeName,
                    Specialization =q.Specialization,
                    Status = "A",
                    UniversityId =q.UniversityId,
                    UniversityName = q.University.UniversityName
                    
                }).ToListAsync();
            var universitySelect = new SelectList(await _db.Mem_UniversityMasters.ToListAsync(),  "Id", "UniversityName");
            var qualificationSelect = new SelectList(await _db.Mem_EducationalQualifications.ToListAsync(), "Id", "DegreeName");


            var editmaster = new EducationQualifictaionEditMasterViewModel
            {
                Qualification = list,
                QualificationList = qualificationSelect,
                UniversityList = universitySelect

            };
            return PartialView("_EditEducationalQualif", editmaster);
        }

        [HttpPost]
        public async Task<IActionResult> EditEducationalQualif(EducationQualifictaionEditMasterViewModel master)
        {
            return Ok();
        }

        public async Task<IActionResult> DeleteEducationalQualif(int? id)
        {
            return View();
        }

        public async Task<IActionResult> EditFamily(int? id)
        {
            return View();
        }
        public async Task<IActionResult> DeleteFamily(int? id)
        {
            return View();
        }
        public async Task<IActionResult> EditWorkDetails(int? id)
        {
            return View();
        }
        public async Task<IActionResult> DeleteWorkDetails(int? id)
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Approve(int? id,bool isActive)
        {
            var editData = await _db.Mem_Masters.FirstOrDefaultAsync(x => x.Id == id);
            editData.IsVarified = isActive;
            await _db.SaveChangesAsync();
            TempData["message"] = Notifications.NormalNotify(isActive ? "Approved " + editData.Name +" Successfully.": "Approval of " +editData.Name+" Cancelled.");
            return RedirectToAction("Index");
        }


        public async Task<MemberDetailsViewModel> GetDetail(int id)
        {
            var memberDetails = await _db.Mem_Masters.AsNoTracking()
              .Include(x => x.UgCollege)
              .Include(x => x.MainGroup)
              .Include(x => x.MembershipInGroups)
                     .ThenInclude(n => n.GroupMaster)
              .Include(x => x.District)
              .Include(y => y.Kids)
              .Include(y => y.SpouseEducation)
              .Include(x => x.EducationDetails)
                  .ThenInclude(x => x.Qualification)
              .Include(x => x.EducationDetails)
                  .ThenInclude(x => x.University)
              .Include(x => x.WorkDetails)
                  .ThenInclude(x => x.Country)
              .Select(x => _mapper.Map<MemberDetailsViewModel>(x))
              .FirstOrDefaultAsync(x => x.Id == id);

            return memberDetails;
        }
      
    }
}