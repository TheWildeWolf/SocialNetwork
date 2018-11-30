using System;

namespace Hadia.Models.DomainModels
{
    public class Mem_InterestedArea
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int InterestedAreaId { get; set; }

        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }

        //Add interested area FK table
    }
}

