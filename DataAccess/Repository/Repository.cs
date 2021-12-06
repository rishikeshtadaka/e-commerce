using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private DbContext context;
        private DbSet<T> _dbSet;
        public Repository(IDbContext context)
        {
            this.context = context.GetDbContext();
            _dbSet = context.GetDbContext().Set<T>();
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public List<T> Get()
        {
            return _dbSet.ToList();
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
