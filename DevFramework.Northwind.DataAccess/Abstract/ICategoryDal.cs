using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        // burada bu tabloya ait farklı işlemler yapılabildiği için her tablo yada class için ayrı bir I...Dal yapısı oluştuyorum
      

    }
}
