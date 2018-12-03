using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hadia.Models.DomainModels
{
    public class Sett_PrivacyInfoCategory
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Sett_PrivacySetting> PrivacySettings { get; set; }
    }
}

