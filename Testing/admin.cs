using CoreHotelRoomBookingAdminPortal.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Testing
{
    [TestClass]
    public class Admin
    {
        static AccountController controller;


        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            controller = new AccountController();
            context.WriteLine("AccountController Instance Created");

        }


        [TestMethod]
        [TestCategory("Account")]
        public void TestForIndexAction()
        {
            //Act
            IActionResult result = controller.Index();
            ViewResult view = (ViewResult)result;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod]
        [TestCategory("Account")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIFLogin()
        {
            //Act
            ViewResult result = (ViewResult)controller.Login("admin", "123456");

            //Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(string));
            Assert.AreEqual(result.ViewName, "Home");


        }


        [TestMethod]
        [TestCategory("Account")]

        public void TestElseLogin()
        {
            //Act
            IActionResult result = controller.Login("admins", "12354");
            ViewResult view = (ViewResult)result;
            string test = "Invalid Credentials";
            string data = (string)view.ViewData["Error"];

            //Assert
            Assert.IsNotNull(view);
            Assert.IsInstanceOfType(view.ViewName, typeof(string));
            Assert.AreEqual(view.ViewName, "Index");
            Assert.AreEqual(test, data);

        }



    }
}
