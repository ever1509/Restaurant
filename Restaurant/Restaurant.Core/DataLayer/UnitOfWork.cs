using Restaurant.Core.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer.Repositories
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected DbContext DbContext;
        protected Boolean Disposed;
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public int CommitChanges()
        {
            if (DbContext.ChangeTracker.HasChanges())
            {
                return DbContext.SaveChanges();
            }
            return 0;
        }

        public Task<int> CommitChangesAsync()
        {
            if (DbContext.ChangeTracker.HasChanges())
            {
                return DbContext.SaveChangesAsync();
            }
            return Task.Run(() => { return 0; });
        }
        protected void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
