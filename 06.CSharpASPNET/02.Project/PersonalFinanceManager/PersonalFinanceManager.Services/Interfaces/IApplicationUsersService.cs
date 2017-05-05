using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.Interfaces
{
    public interface IApplicationUsersService
    {
        ApplicationUser GetUser(string id);
        ICollection<ApplicationUser> GetUsers();
    }
}