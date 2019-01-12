using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models
{

    public class CountryRest
    {
        public string name { get; set; }
        public string[] callingCodes { get; set; }
        public decimal[] latlng { get; set; }
        public string[] timezones { get; set; }
        public string nativeName { get; set; }
    }
}
