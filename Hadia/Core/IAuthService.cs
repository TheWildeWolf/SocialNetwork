﻿using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Core
{
    public interface IAuthService
    {
        Task<Mem_Master> Login(string username, string password);
        Task<bool> UserExists(string email);
    }
}