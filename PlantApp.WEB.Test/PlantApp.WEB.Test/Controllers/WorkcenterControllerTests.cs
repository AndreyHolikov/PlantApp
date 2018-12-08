using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlantApp.DAL.Entities;
using PlantApp.WEB.DTO;
using PlantApp.BLL.Interfaces;
using PlantApp.WEB.Controllers;
using PlantApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlantApp.WEB.Controllers.Tests
{
    [TestClass]
    public class WorkcenterControllerTests
    {
        private List<Workcenter> listWorkcenter;
        private WorkcenterDTO workcenterDto;
        private Mock<ICrudService<Workcenter>> mock;
        private int id;
        private JsonResult jsonResult;


        [TestInitialize]
        public void SetupContext()
        {
            // Arrange
            mock = new Mock<ICrudService<Workcenter>>();
            listWorkcenter = new List<Workcenter>() {
                new Workcenter { Id = 0, Name = "TestWorkcenter.UI"},
                new Workcenter { Id = 1, Name = "TestWorkcenter.WEB"},
                new Workcenter { Id = 2, Name = "TestWorkcenter.BLL"},
                new Workcenter { Id = 3, Name = "TestWorkcenter.DAL"}
            };
            workcenterDto = new WorkcenterDTO() { Id = 1, Name = "TestWorkcenter.WEB" };
            id = (new Random()).Next(1, listWorkcenter.Count());
        }

        #region Index

        [TestMethod]
        public void Index_Result_IsNotNull()
        {
            mock.Setup(a => a.GetAll()).Returns(listWorkcenter);
            WorkcenterController controller = new WorkcenterController(mock.Object);
            
            jsonResult = controller.Index() as JsonResult;

            Assert.IsNotNull(jsonResult.Data);
        }

        [TestMethod]
        public void Index_Result_TypeIsTrue()
        {
            Index_Result_IsNotNull();
            Type expected = typeof(List<WorkcenterDTO>);
            Type actual = jsonResult.Data.GetType();

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Index_Result_CountIsTrue()
        {
            Index_Result_TypeIsTrue();
            List<WorkcenterDTO> listWorkcenterDTOResult
                = jsonResult.Data as List<WorkcenterDTO>;

            Assert.IsTrue(listWorkcenterDTOResult.Count() == listWorkcenter.Count());
        }

        #endregion

        #region Add

        [TestMethod]
        public void AddGetAction_IsNotNull()
        {
            WorkcenterController controller = new WorkcenterController(mock.Object);

            jsonResult = controller.Add() as JsonResult;

            Assert.IsNotNull(jsonResult.Data);
        }

        [TestMethod]
        public void AddGetAction_TypeIsTrue()
        {
            var expected = typeof(WorkcenterDTO);
                
            AddGetAction_IsNotNull();
            var actual = jsonResult.Data.GetType();

            Assert.IsTrue(expected == actual);
        }
        
        public void AddPostAction_Arrange()
        {
            // Arrange 
            Workcenter workcenter = listWorkcenter[2];
            mock.Setup(a => a.Add(workcenter)).Returns(workcenter.Id);
        }

        [TestMethod]
        public void AddPostAction_RouteResult_ActionIsIndex()
        {
            // Arrange 
            string expected = "Index";
            AddPostAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            // Act 
            RedirectToRouteResult result = controller.Add(workcenterDto) as RedirectToRouteResult;
            var actual = result.RouteValues["action"];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddPostAction_ModelError()
        {
            AddPostAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");

            jsonResult = controller.Add(workcenterDto) as JsonResult;

            Assert.IsFalse(controller.ModelState.IsValid);
        }

        #endregion
        #region Edit

        public void EditGetAction_Arrange()
        {
            Workcenter workcenter = listWorkcenter[id];
            mock.Setup(a => a.Get(id)).Returns(workcenter);
        }

        [TestMethod]
        public void EditGetAction_IsNotNull()
        {
            EditGetAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            jsonResult = controller.Edit(id) as JsonResult;

            Assert.IsNotNull(jsonResult.Data);
        }

        [TestMethod]
        public void EditGetAction_TypeIsTrue()
        {
            var expected = typeof(WorkcenterDTO);
            EditGetAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            jsonResult = controller.Edit(id) as JsonResult;

            var actual = jsonResult.Data.GetType();
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void EditPostAction_RouteResult_ActionIsIndex()
        {
            // Arrange 
            string expected = "Index";
            EditGetAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            // Act 
            RedirectToRouteResult result = controller.Edit(workcenterDto) as RedirectToRouteResult;
            var actual = result.RouteValues["action"];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditPostAction_ModelError()
        {
            EditGetAction_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");

            jsonResult = controller.Edit(workcenterDto) as JsonResult;

            Assert.IsFalse(controller.ModelState.IsValid);
        }
        #endregion

        #region Delete

        public void Delete_Arrange()
        {
            Workcenter workcenter = listWorkcenter[id];
            mock.Setup(a => a.Get(id)).Returns(workcenter);
            mock.Setup(a => a.Delete(id));
        }

        [TestMethod]
        public void DeleteGetAction_Result_IsNotNull()
        {
            Delete_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            jsonResult = controller.Delete(id) as JsonResult;

            Assert.IsNotNull(jsonResult.Data);
        }

        [TestMethod]
        public void DeleteGetAction_Result_TypeIsTrue()
        {
            DeleteGetAction_Result_IsNotNull();
            Type expected = typeof(WorkcenterDTO);
            Type actual = jsonResult.Data.GetType();

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void DeletePostAction_RouteResult_ActionIsIndex()
        {
            // Arrange 
            string expected = "Index";
            Delete_Arrange();
            WorkcenterController controller = new WorkcenterController(mock.Object);

            // Act 
            RedirectToRouteResult result = controller.DeleteWorkcenter(id) as RedirectToRouteResult;
            var actual = result.RouteValues["action"];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}