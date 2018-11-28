using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class ProfMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus Type { get; set; }
    }

    public enum MaritalStatus :byte
    {
        [DisplayName("Single")]
        Single=1,
        [DisplayName("Married")]
        Married = 2,
        [DisplayName("Divorced")]
        Divorced = 3
    }
}
