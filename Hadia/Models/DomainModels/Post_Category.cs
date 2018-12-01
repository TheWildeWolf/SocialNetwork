using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Post_Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CLogin { get; set; }

        public int? MLogin { get; set; }
        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public Mem_Master ModifiedBy { get; set; }

        public ICollection<Post_Master> Posts { get; set; }
        public ICollection<Post_Categorypermission> Categorypermissions { get; set; }

    }
}

