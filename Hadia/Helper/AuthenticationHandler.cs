using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hadia.Helper
{
    public class HadiaAuthenticationHandler : AuthenticationHandler<HadiaAuthHandlerOptions>
    {
        public HadiaAuthenticationHandler(IOptionsMonitor<HadiaAuthHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            
           
            return await Context.AuthenticateAsync(Scheme.Name);
        }
    }

    public class HadiaAuthHandlerOptions : AuthenticationSchemeOptions
    {
        public bool Enable { get; set; }
    }
}
