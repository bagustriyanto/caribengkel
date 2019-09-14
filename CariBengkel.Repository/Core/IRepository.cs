using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace CariBengkel.Repository.Core {
    public interface IRepository<T> : IDisposable where T : class {
        void Add (T entity);
        void Add (IEnumerable<T> entities);
        void Update (T entity);
        void Update (IEnumerable<T> entity);
        void Delete (T entity);
        void Delete (IEnumerable<T> entity);
        // IQueryable<T> Query (string sql, params object[] parameters);
        // T Search (params object[] keyValues);
        // T Single (Expression<Func<T, bool>> predicate = null,
        //     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //     bool disableTracking = true);
    }
}