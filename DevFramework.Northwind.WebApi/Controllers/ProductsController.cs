using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController()
        {

        }
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }

        //[AcceptVerbs("GET", "POST")]
        //public Product ById(int id)
        //{
        //    return _productService.GetById(id);
        //}
    }
}
