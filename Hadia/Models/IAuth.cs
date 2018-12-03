using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models
{
    interface IAuthentication
    {
        Task<Mem_Master> Register();
        Task<Mem_Master> Login(string username,string password);
        Task<bool> UserExist(string username);

    }

  
}
