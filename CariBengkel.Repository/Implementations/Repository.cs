using System.Collections.Generic;
using CariBengkel.Repository.Core;
using Microsoft.EntityFrameworkCore;

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

        public void Dispose () {
            _context?.Dispose ();
        }
    }
}