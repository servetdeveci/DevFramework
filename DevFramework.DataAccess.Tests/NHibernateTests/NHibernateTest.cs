using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace DevFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            // normalde boyle kullanım (newlemek) dogru deil. göstermelik boyle yapılacak
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();
            Assert.AreEqual(77, result.Count);

        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            // normalde boyle kullanım (newlemek) dogru deil. göstermelik boyle yapılacak
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);

        }


    }
}
