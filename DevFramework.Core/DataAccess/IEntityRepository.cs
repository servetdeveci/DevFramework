﻿using DevFramework.Core.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T :class, IEntity, new()
    {
        List<T> GetList(Expression<System.Func<T,bool>> filter = null);
        T Get(Expression<System.Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
