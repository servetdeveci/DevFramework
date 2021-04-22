using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        
        // burada bu tabloya ait farklı işlemler yapılabildiği için her tablo yada class için 
        //ayrı bir I...Dal yapısı oluştuyorum
        List<ProductDetail> GetProductDeteails();

    }
}
