using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using System.Web.Mvc;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "yeni urun",
                QuantityPerUnit = "5 tane var",
                UnitPrice = 2
            }, new Product
            {
                CategoryId = 1,
                ProductName = "yeni urun",
                QuantityPerUnit = "5 tane var",
                UnitPrice = 22,
                ProductId = 1
            }
            );
            return "Done";
        }
    }
}