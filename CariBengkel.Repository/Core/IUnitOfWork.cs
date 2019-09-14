using System;
using Microsoft.EntityFrameworkCore;

namespace CariBengkel.Repository.Core {
    public interface IUnitOfWork : IDisposable {
        IRepository<TEntity> GetRepository<TEntity> () where TEntity : class;
        int Commit ();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext {
        TContext Context { get; }
    }
}