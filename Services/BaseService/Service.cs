using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aalgro.ECommerce.Services.BaseService
{
    public abstract class Service<TDomain,TModel> : IService<TModel> where TDomain : BaseEntity where TModel:class
    {
        protected readonly IRepository<TDomain> _repository;
        public Service(IRepository<TDomain> repository)
        {
            _repository = repository;
        }
        protected virtual void DeleteEntity(TDomain entity)
        {
            _repository.Delete(entity);
        }

        protected virtual void DeleteEntity(long Id)
        {
            var entity = GetEntities().Where(t => t.Id == Id).FirstOrDefault();
            DeleteEntity(entity);
        }

        protected virtual TDomain GetEntityById(long Id)
        {
            return GetEntities().Where(t => t.Id == Id).FirstOrDefault();
        }

        protected virtual IQueryable<TDomain> GetEntities()
        {
            return _repository.Get().AsQueryable();
        }

        protected virtual void InsertEntity(TDomain entity)
        {
            _repository.Insert(entity);
        }

        public abstract IQueryable<TModel> Get();
        public abstract TModel GetById(long Id);
        public abstract void Insert(TModel entity);
        public abstract void Delete(TModel entity);
        public abstract void Delete(long Id);
        public abstract void Update(TModel entity);
    }
}
