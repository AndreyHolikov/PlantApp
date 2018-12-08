using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlantApp.WEB.DTO;
using PlantApp.BLL.Interfaces;
using PlantApp.WEB.Controllers;
using PlantApp.DAL.Entities;

namespace PlantApp.Web.Tests.Controllers
{
    [TestClass]
    public class PlantAppHomeControllerTest
    {
        //Arrange 
        //Act 
        //Assert

        [TestMethod]
        public void IndexViewModelIsNotNull()
        {
            // Arrange
            var mock = new Mock<ICrudService<Workcenter>>();
            mock.Setup(a => a.GetAll()).Returns(new List<Workcenter>());
            //mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }



        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
