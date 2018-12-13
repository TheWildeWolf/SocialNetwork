using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Controllers
{
    public class MemberListController : Controller
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public MemberListController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfMember = await _db.Mem_Masters
                 .Select(x => _mapper.Map<MemberViewModel>(x)).ToListAsync();
            return View(ListOfMember);
        }
    }
}