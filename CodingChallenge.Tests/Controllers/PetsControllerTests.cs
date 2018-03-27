using CodingChallenge.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CodingChallenge.Tests.Controllers
{
    [TestClass]
    public class PetsControllerTests
    {
        [TestMethod]
        public void PetsIndex()
        {
            var controller = new PetsController();
            var result = controller.Index() as ViewResult;
            var modelObj = result.ViewData.Model;
            Assert.IsNotNull(modelObj);
        }
    }
}
