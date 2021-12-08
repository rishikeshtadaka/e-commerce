using Aalgro.ECommerce.DataAccess.Repository;
using Aalgro.ECommerce.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        protected async virtual Task DeleteEntityAsync(TDomain entity)
        {
            _repository.Delete(entity);
            await this.SaveChangesAsync();
        }

        protected async virtual Task DeleteEntityAsync(long Id)
        {
            var list = await GetEntitiesAsync();
            var entity = list.Where(t => t.Id == Id).FirstOrDefault();
            await DeleteEntityAsync(entity);
        }

        protected async virtual Task<TDomain> GetEntityByIdAsync(long Id)
        {
            var list = await GetEntitiesAsync();
            return list.Where(t => t.Id == Id).FirstOrDefault();
        }

        protected async virtual Task<IEnumerable<TDomain>> GetEntitiesAsync()
        {
            return await _repository.GetAsync();
        }

        public virtual async Task<IEnumerable<TDomain>> GetEntitiesAsync(Expression<Func<TDomain, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        protected async virtual Task InsertEntity(TDomain entity)
        {
            entity.Id = 0;//To generate auto id.
            await _repository.InsertAsync(entity);
            await this.SaveChangesAsync();
        }

        protected async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public abstract Task<IEnumerable<TModel>> Get();
        public abstract Task<TModel> GetById(long Id);
        public abstract Task Insert(TModel entity);
        public abstract Task Delete(TModel entity);
        public abstract Task Delete(long Id);
        public abstract Task Update(TModel entity);
    }
}
