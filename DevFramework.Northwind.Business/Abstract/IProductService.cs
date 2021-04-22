using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    /// <summary>
    /// IProductservice in  service olması için WCF için çeşitli çözümler yapmalıyyız
    /// SOA ya göre bu class a  bir kontrat verioruz
    /// ServiceContract tamamen WCF ile alakalı bir şey. 
    /// eğer WCF kullanmazsak bise yapmamıza gerek kalmaz
    /// 
    /// </summary>
    /// 
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();
        [OperationContract]

        Product GetById(int Id);
        [OperationContract]

        Product Add(Product product);
        [OperationContract]

        Product Update(Product product);
        [OperationContract]

        void TransactionalOperation(Product product1, Product product2);
    }
}
