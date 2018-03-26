using CodingChallenge.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodingChallenge.Tests.Controllers
{
    [TestClass]
    class PeopleControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PeopleController controller = new PeopleController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
