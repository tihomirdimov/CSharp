﻿using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface IApplicationUserService
    {
        ApplicationUser GetUser(string id);
    }
}