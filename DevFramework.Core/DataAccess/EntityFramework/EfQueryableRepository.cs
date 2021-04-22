using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        // Dependency Injection yapıyoruz. Başka contextleride kullabilieceğim için
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }


        //public IQueryable<T> Table
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}
        // yukarıdaki kodun yeni nesil yazılısı
        // Iqueryable Table cagrıldığında bunun tablosunu dondur demek
        public IQueryable<T> Table => this.Entities;

        //protected virtual IDbSet<T> Entities
        //{
        //    get
        //    {
        //        if (_entities == null)
        //        {
        //            return _entities;
        //        }
        //        return _entities;
        //    }
        //}
        // yukarıdaki kodun yeni nesil yazılısı
        // Table ile çağrıldığında context in hangi tablosunun dondureleceğini set ediyoruz
        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }

        }
    }
}
