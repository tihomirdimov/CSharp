using System;
using System.Security.Principal;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonalFinanceManager.Controllers;

namespace PersonalFinanceManager.Tests.Controllers
{
    [TestClass]
    public class TestHomeController
    {
        private readonly HomeController _controller = new HomeController();

        [TestMethod]
        public void Retrieve_Index()
        {
            var result = _controller.Index();
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        public void Retrieve_IndexLoggedIn()
        {
            var controllerContext = new Mock<ControllerContext>();
            var principal = new Moq.Mock<IPrincipal>();
            principal.Setup(p => p.IsInRole("Admin")).Returns(true);
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            _controller.ControllerContext = controllerContext.Object;

            var result = _controller.Index();

            Assert.IsNotNull(result);
        }
    }
}
