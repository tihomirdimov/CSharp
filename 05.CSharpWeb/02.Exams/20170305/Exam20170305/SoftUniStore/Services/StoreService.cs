using System.Linq;
using System.Text.RegularExpressions;
using SoftUniStore.BindingModels;
using SoftUniStore.Models;

namespace SoftUniStore.Services
{
    class StoreService : Service
    {
        public bool IsRegisterViewModelValid(RegisterUserBindingModel registerUserBindingModel)
        {
            if (!registerUserBindingModel.Email.Contains("@") || !registerUserBindingModel.Email.Contains("."))
            {
                return false;
            }

            if (this.Context.Users.Any(user => user.Email == registerUserBindingModel.Email))
            {
                return false;
            }

            if (registerUserBindingModel.Password.Length < 6)
            {
                return false;
            }

            Regex usernameRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).+$");
            if (!usernameRegex.IsMatch(registerUserBindingModel.Password))
            {
                return false;
            }

            if (registerUserBindingModel.Password != registerUserBindingModel.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel registerUserBindingModel)
        {
            return new User()
            {
                Email = registerUserBindingModel.Email,
                Password = registerUserBindingModel.Password,
            };
        }

        public void RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool IsLoginViewModelValid(LoginUserBindingModel loginUserBindingModel)
        {
            return this.Context.Users.Any(
                user => user.Email == loginUserBindingModel.Email && user.Password == loginUserBindingModel.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel loginUserBindingModel)
        {
            return this.Context.Users.First(
                user => user.Email == loginUserBindingModel.Email && user.Password == loginUserBindingModel.Password);
        }

        public void LoginUser(User user, string sessionId)
        {

            this.Context.Logins.Add(new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            });
            this.Context.SaveChanges();
        }
    }
}
