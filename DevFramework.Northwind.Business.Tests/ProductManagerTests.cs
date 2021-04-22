using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
       // [ExpectedException(typeof(ValidationException))]
        [ExpectedException(typeof(System.NullReferenceException))]
        [TestMethod]
        public void Product_validation_check()
        {
            //Mock<IProductDal> mock = new Mock<IProductDal>();
            //ProductManager productManager = new ProductManager(mock.Object);
            //productManager.Add(new Product());
        }
    }
}
