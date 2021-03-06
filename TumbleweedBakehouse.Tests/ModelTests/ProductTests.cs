
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using TumbleweedBakehouse.Models;

namespace TumbleweedBakehouse.Tests
{
  [TestClass]
  public class ProductTest : IDisposable
  {

   public void Dispose()
    {
      Product.ClearAll();
      Order.ClearAll();
    }

    public ProductTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tumbleweedbakehouse_test;";
    }

    [TestMethod]
    public void ProductConstructor_CreatesInstanceofProduct_Product()
    {
      Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);

      Assert.AreEqual(typeof(Product),testProduct.GetType());
    }

    [TestMethod]
    public void GetProductAvailability_ReturnsAvailabilityValue_Boolean()
    {
      bool testBool = true;
      Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",testBool,3,1);

      bool result = testProduct.GetProductAvailability();

      Assert.AreEqual(testBool, result);
    }

    [TestMethod]
    public void SetProductAvailability_SetsAvailabilityValue_Boolean()
    {
      bool testBool = true;
      Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",false,3,1);
      testProduct.Save();

      testProduct.SetProductAvailability(testBool);

      bool result = testProduct.GetProductAvailability();

      Assert.AreEqual(testBool, result);
    }

    [TestMethod]
    public void Getall_GetEmptyList_List()
    {
      List<Product> productList = new List<Product>{};
      List<Product> result = Product.GetAll();

      CollectionAssert.AreEqual(productList,result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ProductList()
    {
      //Arrange
     Product firstProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);
      firstProduct.Save();

      List<Product> newList = new List<Product> { firstProduct};

      //Act
      List<Product> result = Product.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ProductList()
    {
      //Arrange
     Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);

      //Act
      testProduct.Save();
      List<Product> result = Product.GetAll();
      List<Product> testList = new List<Product>{testProduct};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
     Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);

      //Act
      testProduct.Save();
      Product savedProduct = Product.GetAll()[0];

      int result = savedProduct.GetId();
      int testId = testProduct.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Product()
    {
      //Arrange
      Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);
      testProduct.Save();

      //Act
      Product foundProduct = Product.Find(testProduct.GetId());

      //Assert
      Assert.AreEqual(testProduct, foundProduct);
    }

    [TestMethod]
    public void Edit_UpdatesProductInDatabase_True()
    {
      //Arrange
      Product testProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);
      testProduct.Save();

      string breadname = "miniWheat";
      string type = "shoe";
      string description = "leathery";
      string url = "/img";
      bool availability = false;
      int price = 4;

      testProduct.Edit(breadname, type, description, url, availability, price);


      Product result = Product.Find(testProduct.GetId());

      Assert.AreEqual(testProduct, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfCustomersAreTheSame_Product()
    {
      // Arrange, Act
      Product firstProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);
      Product secondProduct = new Product("sourdough","raye","light and fluffy","hello.com",true,3,1);

      // Assert
      Assert.AreEqual(firstProduct, secondProduct);
    }

  }
}
