using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        // Dependency Injection yapıyoruz. Başka contextleride kullabilieceğim için
        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
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

        //protected virtual IQueryable<T> Entities
        //{
        //    get
        //    {
        //        if (_entities == null)
        //        {
        //            return _nHibernateHelper.OpenSession().Query<T>();
        //        }
        //        return _entities;
        //    }
        //}
        // yukarıdaki kodun yeni nesil yazılısı
        // Table ile çağrıldığında session in hangi tablosunun dondureleceğini set ediyoruz

        protected virtual IQueryable<T> Entities
        {
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }

        }
    }
}
