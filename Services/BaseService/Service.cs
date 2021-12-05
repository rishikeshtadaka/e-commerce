using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.BaseService
{
    public abstract class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual void Delete(long Id)
        {
            var entity = Get().Where(t => t.Id == Id).FirstOrDefault();
            Delete(entity);
        }

        public virtual T GetById(long Id)
        {
            return Get().Where(t => t.Id == Id).FirstOrDefault();
        }

        public virtual IQueryable<T> Get()
        {
            return _repository.Get().AsQueryable();
        }

        public virtual void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public abstract void Update(T entity);

    }
}
