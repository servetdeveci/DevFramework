using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService:IProductService
{
    private readonly IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    /// <summary>
    /// SOA da parametreli conts olmadığı için constructor a injection yapmıyoruz. 
    /// 
    /// </summary>
    /// <param name="productService"></param>
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Product Add(Product product)
    {
        return _productService.Add(product);

    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int Id)
    {
        return _productService.GetById(Id);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        _productService.TransactionalOperation(product1, product2);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }
}