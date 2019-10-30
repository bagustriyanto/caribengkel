using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CariBengkel.Repository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CariBengkel.Repository.Implementations {
    public class Repository<T> : IRepository<T> where T : class {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;
        public Repository (DbContext context) {
            _context = context;
            _set = _context.Set<T> ();
        }

        public void Add (T entity) {
            _set.Add (entity);
        }

        public void Add (IEnumerable<T> entities) {
            _set.AddRange (entities);
        }

        public void Update (T entity) {
            _set.Update (entity);
        }

        public void Update (IEnumerable<T> entities) {
            _set.UpdateRange (entities);
        }

        public void Delete (T entity) {
            var existing = _set.Find (entity);
            if (existing != null)
                _set.Remove (existing);
        }

        public void Delete (IEnumerable<T> entities) {
            _set.RemoveRange (entities);
        }

        public virtual IQueryable<T> Query (string sql, params object[] parameters) => _set.FromSql (sql, parameters);

        public T Search (params object[] keyValues) => _set.Find (keyValues);

        public T Single (Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true) {
            IQueryable<T> query = _set;
            if (disableTracking) query = query.AsNoTracking ();

            if (include != null) query = include (query);

            if (predicate != null) query = query.Where (predicate);

            if (orderBy != null)
                return orderBy (query).FirstOrDefault ();

            return query.FirstOrDefault ();
        }

        public void Dispose () {
            _context?.Dispose ();
        }
    }
}