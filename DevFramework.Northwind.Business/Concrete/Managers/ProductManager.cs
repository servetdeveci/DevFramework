using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevFramework.Core.Utilities.Mapper;
using AutoMapper;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IQueryableRepository<Product> _queryable;
        private readonly IMapper _mapper;
        //public ProductManager(IProductDal productDal, IQueryableRepository<Product> queryable)
        //{
        //    _productDal = productDal;
        //    _queryable = queryable;
        //}
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ProductValidator))]// aspect olarak yazılan kod
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            // aşagıdaki kodu aspect orienting prgramin ile yukarıda yapıyoruz
            // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager),120)] // default olarak 60 dk vermistik.
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        //[SecuredOperation(Roles="Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            //// normal şartlarda kodlarda gelen entity nesnesi serilestirilemiyor bu yuzden aşağıdaki select işlemini yapıyorm. 
            //// ilk olarak bu şekildeydi (1)
            //return _productDal.GetList().Select(p => new Product
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    UnitPrice = p.UnitPrice,
            //}).ToList();

            //// AutoMapper kullanarak mapping yaptık. Serialize oldu
            //// ikinci olarak generic bir automapper yaptık. (2) 
            //List<Product> products =AutoMapperHelper.MapToSameTypeList<Product>(_productDal.GetList());

            List<Product> products = _mapper.Map<List<Product>>(_productDal.GetList());

            return products;
        }

        

        public Product GetById(int Id)
        {
            return _productDal.Get(p => p.ProductId == Id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]// aspect olarak yazılan kod
        [TransactionScopeAspect] // bu kodlar artık gidip try catch ile işlem yapacak işlem olursa commit olmazsa dispose olacak
        public void TransactionalOperation(Product product1, Product product2)
        {
            //// Yukaruda TransactionScopeAspect ile try cathc yapmış olacak
            _productDal.Add(product1);
            //business code .......
            _productDal.Update(product2);

            //// Kotu yazılan kod. bu seekilde yapılabilir fakat bu sefer heryerde bunu yazmamıs gerekir
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    try
            //    {
            //        _productDal.Add(product1);
            //        //business code .......
            //        _productDal.Update(product2);
            //    }
            //    catch
            //    {
            //        scope.Dispose();
            //    }
            ////////////
            //}


        }
        [FluentValidationAspect(typeof(ProductValidator))]// aspect olarak yazılan kod
        public Product Update(Product product)
        {
            // aşagıdaki kodu aspect orienting prgramin ile yukarıda yapıyoruz
            //FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
