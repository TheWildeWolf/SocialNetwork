using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Member.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Controllers
{
    public class BatchController : BasePostController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public BatchController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult>Index()
        {
           var ListOfBatch=await _db.Post_GroupMasters
                .Select(x=>_mapper.Map<BatchViewModel>(x)).ToListAsync();
            return View(ListOfBatch);
        }

        public IActionResult Create()
        {

        }
    }
}