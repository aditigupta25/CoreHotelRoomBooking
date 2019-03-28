using CoreHotelRoomBookingAdminPortal.Controllers;
using CoreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {

        static HotelController controller;
        
        [ClassInitialize]
        public static void ClassInt(TestContext context)
        {
            controller = new HotelController();
            context.WriteLine("Hotel Controller instance created");
        }


        [TestMethod]
        [TestCategory("HotelTests")]
        public void TestForIndexAction()
        {
            //Arrange


            //Act
            ViewResult result = (ViewResult)controller.Index();

            //
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Hotel>));
        }

        [TestMethod]
        [TestCategory("HotelTests")]
        public void TestForDetails()
        {

        }
    }
}
