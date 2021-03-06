using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TumbleweedBakehouse.Controllers;
using TumbleweedBakehouse.Models;
using System;

namespace TumbleweedBakehouse.Tests
{
    [TestClass]
    public class CustomerControllerTests : IDisposable
    {
    public void Dispose()
    {
      Customer.ClearAll();
    }
   public CustomerControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tumbleweedbakehouse;";
    }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            CustomerController controller = new CustomerController();
            //Act
            ActionResult indexView = controller.Index();
            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
        [TestMethod]
        public void Index_HasCorrectModelType_CustomerList()
        {
          List<Customer> emptyList = new List<Customer> { };
          ViewResult  indexView = new CustomerController().Index() as ViewResult;
          var result = indexView.ViewData.Model;
          Assert.IsInstanceOfType(result, typeof(List<Customer>));
        }
        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult editView = controller.Edit(0);
          Assert.IsInstanceOfType(editView,typeof(ViewResult));
        }
        [TestMethod]
        public void Edit_HasCorrectModelType_Dictionary()
        {
          ViewResult editView = new CustomerController().Edit(1) as ViewResult;
          var result = editView.ViewData.Model;
          Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
        [TestMethod]
        public void Create_RedirectsToCorrectAction_Index()
        {
          CustomerController controller = new CustomerController();
          RedirectToActionResult actionResult = controller.Create("Ty","Butts","123123312234", "google@gmail.com", "Some road somewhere", "Portland", "Maine", 22030) as RedirectToActionResult;
          string result = actionResult.ActionName;
          Assert.AreEqual(result, "index");
        }
        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult newView = controller.New();
          Assert.IsInstanceOfType(newView,typeof(ViewResult));
        }
        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
          CustomerController controller = new CustomerController();
          ActionResult showView = controller.Show(1);
          Assert.IsInstanceOfType(showView,typeof(ViewResult));
        }
        [TestMethod]
        public void Show_HasCorrectModelType_Dictionary()
        {
          ViewResult editView = new CustomerController().Show(0) as ViewResult;
          var result = editView.ViewData.Model;
          Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
    }
}
