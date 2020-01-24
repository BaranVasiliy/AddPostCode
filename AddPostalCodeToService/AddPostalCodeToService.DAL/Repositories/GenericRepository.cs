using AddPostalCodeToService.DAL.DataContext;
using AddPostalCodeToService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddPostalCodeToService.DAL.Repositories
{
    public class GenericRepository<TId, TEntity> : IGenericRepository<TId, TEntity> where TEntity : class
    {
        protected ContextDb Context;

        public GenericRepository(ContextDb context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}