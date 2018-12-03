using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{

    public class CountryApi
    {
        public string name { get; set; }
        public string[] callingCodes { get; set; }
        public string[] timezones { get; set; }
    }
}
