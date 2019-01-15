using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Core
{
    public interface IResetPassword
    {
        Task<bool> ResetAsync(Mem_Master user,string password);
    }
}
