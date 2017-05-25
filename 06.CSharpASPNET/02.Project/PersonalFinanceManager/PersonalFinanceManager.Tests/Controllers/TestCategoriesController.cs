using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Tests.TestServices;
using PersonalFinanceManager.ViewModels.Categories;

namespace PersonalFinanceManager.Tests.Controllers
{
    [TestClass]
    public class TestCategoriesController
    {
        private readonly CategoriesController _controller = new CategoriesController(new TestCategoriesService());

        [TestMethod]
        public void Test_Create()
        {
            CategoriesFormVM categoryFormVM = new CategoriesFormVM()
            {
                Id = 0,
                Name = "Utilities"
            };

            var username = "tisho@tisho.com";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);

            identity.AddClaim(nameIdentifierClaim);

            var user = new Mock<IPrincipal>();
            user.Setup(x => x.Identity).Returns(identity);
            user.Setup(x => x.IsInRole("Admin")).Returns(true);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(user.Object);
            _controller.ControllerContext = controllerContext.Object;

            //var controllerContext = new Mock<ControllerContext>();
            //var user = new Mock<IPrincipal>();
            //user.Setup(p => p.IsInRole("Admin")).Returns(true);
            //user.SetupGet(x => x.Identity.Name).Returns("tisho01");
            //controllerContext.SetupGet(x => x.HttpContext.User).Returns(user.Object);
            //_controller.ControllerContext = controllerContext.Object;

            var result = _controller.Create(categoryFormVM);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Edit()
        {
            CategoriesFormVM categoryFormVM = new CategoriesFormVM()
            {
                Id = 1,
                Name = "Utilities"
            };

            var controllerContext = new Mock<ControllerContext>();
            var user = new Mock<IPrincipal>();
            user.Setup(p => p.IsInRole("Admin")).Returns(true);
            user.SetupGet(x => x.Identity.Name).Returns("tisho01");
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(user.Object);
            _controller.ControllerContext = controllerContext.Object;

            var result = _controller.Create(categoryFormVM);

            Assert.IsNotNull(result);
        }
    }
}
