using System.Linq;
using PersonalFinanceManager.Data.Data;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Services.ControllerServices
{
    public class ApplicationUsersService
    {
        public ApplicationUser GetUser(PfmDbContext context, string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
