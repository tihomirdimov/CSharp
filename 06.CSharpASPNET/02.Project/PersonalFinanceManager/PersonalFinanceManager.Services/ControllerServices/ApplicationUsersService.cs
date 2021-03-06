﻿using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;
using PersonalFinanceManager.Services.Interfaces;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly PfmDbContext _context;

        public ApplicationUsersService()
        {
            _context = new PfmDbContext();
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
