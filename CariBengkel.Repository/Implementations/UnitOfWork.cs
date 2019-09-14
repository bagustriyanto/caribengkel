using System;
using System.Collections.Generic;
using CariBengkel.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace CariBengkel.Repository.Implementations {
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext, IDisposable {
        private Dictionary<Type, object> _repositories;
        public TContext Context { get; }
        public UnitOfWork (TContext context) {
            Context = context;
        }

        public void Dispose () {
            Context?.Dispose ();
        }

        public int Commit () {
            return Context.SaveChanges ();
        }

        public IRepository<TEntity> GetRepository<TEntity> () where TEntity : class {
            if (_repositories == null) _repositories = new Dictionary<Type, object> ();

            var type = typeof (TEntity);
            if (!_repositories.ContainsKey (type)) _repositories[type] = new Repository<TEntity> (Context);
            return (IRepository<TEntity>) _repositories[type];
        }
    }
}