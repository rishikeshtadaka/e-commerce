using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IUnitOfWork _unitOfWork;
        private DbSet<T> _dbSet;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.DBInstance.Set<T>();
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
            _unitOfWork.DBInstance.SaveChanges();
        }
    }
}
