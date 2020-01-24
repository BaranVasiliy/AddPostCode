using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddPostalCodeToService.DAL.Repositories.Contracts
{
    public interface IGenericRepository<in TId, TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TId id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}