﻿namespace SoftUniStore.Utilities
{
    using System.Linq;
    using SoftUniStore.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    class UserAuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Data.Context.Logins.Any(login => login.SessionId == sessionId && login.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Data.Context.Logins.First(login => login.SessionId == sessionId && login.IsActive).User;
            if (user != null)
            {
                ViewBag.Bag["username"] = user.Email;
            }
            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            Login currentLogin = Data.Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Data.Data.Context.SaveChanges();
            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}