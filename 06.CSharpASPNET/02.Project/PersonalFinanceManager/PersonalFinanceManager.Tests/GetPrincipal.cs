using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using Moq;

namespace PersonalFinanceManager.Tests
{
    public static class Principal
    {
        public static IPrincipal GetPrincipal()
        {
            //use an actual identity fake
            var username = "tisho@tisho.com!@#@%#^!";
            var identity = new GenericIdentity(username, "");
            //create claim and add it to indentity
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);
            identity.AddClaim(nameIdentifierClaim);

            var user = new Mock<IPrincipal>();
            user.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = user.Object;
            return user.Object;
        }
    }
}
