using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.ApplicationUsersService
{
    public class ApplicationUsersService : DbService
    {
        public ApplicationUser GetUser(string id)
        {
            return Context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
