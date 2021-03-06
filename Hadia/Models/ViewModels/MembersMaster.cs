﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Helper;

namespace Hadia.Models.ViewModels
{
    public class MembersMasterViewModel
    {
        public int? ChapterId { get; set; }
        public int? BatchId { get; set; }
        public int? UgCollageId { get; set; }
        public string Approval { get; set; }
        public string Name { get; set; }

        public SelectList ChapterList { get; set; }
        public SelectList BatchList { get; set; }
        public SelectList UgCollegeList { get; set; }
        public string SortOrder { get; set; }

        public PaginatedList<MemberViewModel> Members { get; set; }
    }
}
