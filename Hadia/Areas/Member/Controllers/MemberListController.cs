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
                catch (Exception ex)
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
        /*
                [HttpGet]
                public async Task<IActionResult> EditEducationalQualif(int? id)
                {
                    var list = await _db.Mem_EducationDetails
                                   .Include(n => n.Qualification)
                                   .Include(n => n.University)
                        .Where(x => x.MemberId == id)
                        .Select(q => new EducationQualifictaionEditViewModel
                        { Id=q.Id,
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
                    var Editmaster = new EducationQualifictaionEditMasterViewModel
                    {
                        Qualification = list,
                        QualificationList = qualificationSelect,
                        UniversityList = universitySelect

                    };
                    return PartialView("_EditEducationalQualif", Editmaster);
                }
              */
        [HttpGet]
        public async Task<IActionResult> EditEducationalQualif(int?id)
        {
            var list = await _db.Mem_EducationDetails
                                     //.Include(n => n.Qualification)
                                     //.Include(n => n.University)
                          .Where(x => x.Id == id)
                          .Select(q => _mapper.Map<EducationQualifictaionEditViewModel>(q)).FirstOrDefaultAsync(x => x.Id == id);
            var universitySelect = new SelectList(await _db.Mem_UniversityMasters.ToListAsync(), "Id", "UniversityName",list.UniversityId);
            var qualificationSelect = new SelectList(await _db.Mem_EducationalQualifications.ToListAsync(), "Id", "DegreeName",list.EducationQualificationId);
            // EducationalDetails.Qualification = list;
            list.QualificationList = qualificationSelect;
            list.UniversityList = universitySelect;
            return PartialView("_EditEducationalQualif",list);
        }

      /*
        [HttpPost]
        public async Task<IActionResult> AddEducationalQualif(int id, EducationQualifictaionEditMasterViewModel EducationalDetails)
        {
           
            if (ModelState.IsValid)
            {
      
                    EducationalDetails.Qualification.Add(new EducationQualifictaionEditViewModel {
                    Id = 0,
                    EducationQualificationId = EducationalDetails.QualificationId,
                    PassoutYear = new DateTime(EducationalDetails.PassoutYear, 01, 01),
                    PhdTopic = EducationalDetails.PhdTopic,
                    QualificationName = _db.Mem_EducationalQualifications.Find(EducationalDetails.QualificationId).DegreeName,
                    Specialization = EducationalDetails.Specialization,
                    Status = "A",
                    UniversityId = EducationalDetails.UniversityId,
                    UniversityName = _db.Mem_UniversityMasters.Find(EducationalDetails.UniversityId).UniversityName
            });
                ModelState.Clear();
                var universitySelect = new SelectList(await _db.Mem_UniversityMasters.ToListAsync(), "Id", "UniversityName");
                var qualificationSelect = new SelectList(await _db.Mem_EducationalQualifications.ToListAsync(), "Id", "DegreeName");
                // EducationalDetails.Qualification = list;
                EducationalDetails.QualificationList = qualificationSelect;
                EducationalDetails.UniversityList = universitySelect;
                //EducationalDetails.PassoutYear = 0;
                //EducationalDetails.Specialization = null;
            }
          
            return PartialView("_EditEducationalQualif", EducationalDetails);
        }
        */
        [HttpPost]
        public async Task<IActionResult> EditEducationalQualif(int?id, EducationQualifictaionEditViewModel EducationalDetails)
        {
          
                //var EduSave = new Mem_EducationDetail();
                //foreach (var item in EducationalDetails.Qualification.Where(x => x.Id == 0))
                //{
                //    await _db.Mem_EducationDetails.AddAsync(new Mem_EducationDetail
                //    {
                //        EducationQualificationId = item.Edu
                //cationQualificationId,
                //        MemberId = Memid,
                //        UniversityId = item.UniversityId,
                //        PassoutYear = item.PassoutYear,
                //        Specialization = item.Specialization,
                //        CDate = DateTime.Now,
                //    });
                //}

                if (ModelState.IsValid)
                {
                var universitySelect = new SelectList(await _db.Mem_UniversityMasters.ToListAsync(), "Id", "UniversityName");
                var qualificationSelect = new SelectList(await _db.Mem_EducationalQualifications.ToListAsync(), "Id", "DegreeName");
                // EducationalDetails.Qualification = list;
                var dataInDb = _db.Mem_EducationDetails.Find(id);
                    var editMaster = _mapper.Map(EducationalDetails, dataInDb);
                try
                {
                    await _db.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                  
                }
               
                return PartialView("_ViewEducationalQualif", EducationalDetails);
        }

        public async Task<IActionResult> DeleteEducationalQualif(int? id)
        {
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> KidsList(int? id)
        {
            var KidsDetails = await _db.Mem_Kids
                .Select(x => _mapper.Map<KidViewModel>(x)).ToListAsync();
            return PartialView("_KidsView", KidsDetails);
        }

        [HttpGet]
        public async Task<IActionResult> EditKids(int? id)
        {
            var KidsDetails = await _db.Mem_Kids
                .Select(x => _mapper.Map<KidViewModel>(x)).FirstOrDefaultAsync(x => x.Id == id);
             return PartialView("_KidsEdit", KidsDetails);
        }
        [HttpPost]
        public async Task<IActionResult> EditKids(int id, KidViewModel kidsDetails)
        {
            if (ModelState.IsValid)
            {
                var dataInDb = _db.Mem_Kids.Find(id);
                var editMaster = _mapper.Map(kidsDetails, dataInDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_KidsView", kidsDetails);
        }

        [HttpGet]
        public IActionResult CreateKids()
        {

            return PartialView("_AddKids");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateKids(int Mid, KidViewModel kidView)
        {

            if (ModelState.IsValid)
            {
                var newKid = _mapper.Map<Mem_Kid>(kidView);
                newKid.MemberId = Mid;
                newKid.CDate = DateTime.Now;
                await _db.Mem_Kids.AddAsync(newKid);
                await _db.SaveChangesAsync();
                TempData["message"] = Notifications.SuccessNotify("New Kid Added!");
            }
            return PartialView("_KidsView", kidView);
        }
        


        [HttpGet]
        public async Task<IActionResult> EditSpouse(int id)
        {
            var SpouseDetails = await _db.Mem_Masters.AsNoTracking()
                 .Include(y => y.SpouseEducation)
                 .Select(x => _mapper.Map<MemberDetailsViewModel>(x))
              .FirstOrDefaultAsync(x => x.Id == id);
            SpouseDetails.SpouseEduList =
                new SelectList(_db.Mem_SpouseEducationMasters.ToList(), "Id", "QualificationName", SpouseDetails.SpouseEducationId);

            return PartialView("_SpouseEdit", SpouseDetails);


        }
        [HttpPost]
        public async Task<IActionResult> EditSpouse(int id,MemberDetailsViewModel details)
        {
            var dataInDb = _db.Mem_Masters.Find(id);
           // var editMaster = _mapper.Map(details, dataInDb);
            dataInDb.SpouseName = details.SpouseName;
            dataInDb.SpouseAge = DateTime.Now.AddYears(-details.SpouseAge??0); 
            dataInDb.SpouseEducationId = details.SpouseEducationId;
            await _db.SaveChangesAsync();
            details = await GetDetail(id);
            return PartialView("_SpouseView", details);
        }
            public async Task<IActionResult> DeleteFamily(int? id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditWork(int? id)
        {

            var EditData = await _db.Mem_WorkDetails.Select(x => _mapper.Map<WorkDetailsViewModel>(x))
               .FirstOrDefaultAsync(x => x.Id == id);
            var Countryselctlist = new SelectList(_db.Mem_CountryCodes.ToList(), "Id", "CountryName", EditData.CountryId);
            EditData.CountryList = Countryselctlist;
            if (EditData == null)
                return NotFound();
            return PartialView("_WorkEdit",EditData);
        }
        [HttpPost]
        public async Task<IActionResult> EditWork(int id,WorkDetailsViewModel workView)
        {
            if (ModelState.IsValid)
            {
                var dataInDb = _db.Mem_WorkDetails.Find(id);
                var editMaster = _mapper.Map(workView, dataInDb);
                _db.Update(editMaster);
                try
                {
                    await _db.SaveChangesAsync();
                    var memd = await GetDetail(dataInDb.MemberId);
                    return PartialView("_WorkView", memd);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

               
            }
            return PartialView("_WorkView",workView);
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
            TempData["message"] = Notifications.NormalNotify(isActive ? "Approved " + editData.Name +".": "Approval of " +editData.Name+" Cancelled.");
            return RedirectToAction("Index");
        }

        public async Task<ActionResult>DeleteMember(int id)
        {

            var memberDetails = await _db.Mem_Masters.FindAsync(id);
            var KidsDel =await _db.Mem_Kids.Where(x => x.MemberId == id).ToListAsync();
            var EducationDel = await _db.Mem_EducationDetails.Where(x => x.MemberId == id).ToListAsync();
            var WorkDel= await _db.Mem_WorkDetails.Where(x => x.MemberId == id).ToListAsync();
            var MemberShipDel = await _db.Post_GroupMembers.Where(x => x.MemberId == id).ToListAsync();
            _db.Post_GroupMembers.RemoveRange(MemberShipDel);
            _db.Mem_Kids.RemoveRange(KidsDel);
            _db.Mem_EducationDetails.RemoveRange(EducationDel);
            _db.Mem_WorkDetails.RemoveRange(WorkDel);
            _db.Mem_Masters.RemoveRange(memberDetails);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<MemberDetailsViewModel> GetDetail(int id)
        {
            var memberDetails = await _db.Mem_Masters.AsNoTracking()
              .Include(x => x.UgCollege)
              .Include(x => x.MainGroup)
              .Include(x => x.MembershipInGroups)//
                     .ThenInclude(n => n.GroupMaster)
              .Include(x => x.District)
              .Include(y => y.Kids)//
              .Include(y => y.SpouseEducation)
              .Include(x => x.EducationDetails)//
                  .ThenInclude(x => x.Qualification)
              .Include(x => x.EducationDetails)
                  .ThenInclude(x => x.University)
              .Include(x => x.WorkDetails)//
                  .ThenInclude(x => x.Country)
              .Select(x => _mapper.Map<MemberDetailsViewModel>(x))
              .FirstOrDefaultAsync(x => x.Id == id);
            return memberDetails;
        }
        public async Task<IActionResult>Project(int id)
        {
            var ProjectDetails = await _db.Mem_ProjectWorks.ToListAsync();
            return View();
        }
      
    }
}