using SharePaint.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePaint.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task Create(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(string id);
        Task<TEntity> Get(string id);
        Task<List<TEntity>> Get();
    }
}
