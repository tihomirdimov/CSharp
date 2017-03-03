namespace PizzaForum.Service
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using PizzaForum.BindingModels;
    using PizzaForum.Models;

    public class ForumService : Service
    {
        public bool IsRegisterViewModelValid(RegisterUserBindingModel registerUserBindingModel)
        {
            if (registerUserBindingModel.Username.Length < 3)
            {
                return false;
            }
            Regex usernameRegex = new Regex("^[a-z0-9]+$");
            if (!usernameRegex.IsMatch(registerUserBindingModel.Username))
            {
                return false;
            }

            if (this.Context.Users.Any(user => user.Username == registerUserBindingModel.Username ||
             user.Email == registerUserBindingModel.Email))
            {
                return false;
            }

            if (!registerUserBindingModel.Email.Contains("@"))
            {
                return false;
            }
            Regex passRegex = new Regex("^[0-9]{4}$");
            if (!passRegex.IsMatch(registerUserBindingModel.Password) ||
                registerUserBindingModel.Password != registerUserBindingModel.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel registerUserBindingModel)
        {
            return new User()
            {
                Username = registerUserBindingModel.Username,
                Password = registerUserBindingModel.Password,
                Email = registerUserBindingModel.Password
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
                user =>
                (user.Username == loginUserBindingModel.Credential ||
                user.Email == loginUserBindingModel.Credential) &&
                user.Password == loginUserBindingModel.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel loginUserBindingModel)
        {
            return this.Context.Users.First(
                user =>
                (user.Username == loginUserBindingModel.Credential ||
                user.Email == loginUserBindingModel.Credential) &&
                user.Password == loginUserBindingModel.Password);
        }

        public void LoginUser(User user, string sessionId)
        {

            this.Context.Logins.Add(new Login()
            {
                SessinId = sessionId,
                User = user,
                isActive = true
            });
            this.Context.SaveChanges();
        }
    }
}
