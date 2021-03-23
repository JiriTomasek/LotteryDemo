using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Entities.DAO
{
    public interface ICommonDao<TEntity>
    {
        IEnumerable<TEntity> AddRangeItems(IEnumerable<TEntity> entities);
        TEntity AddItem(TEntity entity);
        Task<TEntity> AddItemAsync(TEntity entity);
        void DeleteItem(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> deleteList);
        IEnumerable<TEntity> UpdateRangeItems(IEnumerable<TEntity> entities);
        TEntity UpdateItem(TEntity entity);

        Task<TEntity> UpdateItemAsync(TEntity entity);

        TEntity GetSingle(Func<TEntity, bool> condition, bool asNoTracking = true, Including including = null);
        IEnumerable<TEntity> GetCollection(Func<TEntity, bool> condition = null,  bool asNoTracking = true, Including including = null);

        IQueryable<TEntity> GetCollectionIQueryable(Func<TEntity, bool> condition = null,  bool asNoTracking = true, Including including = null);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> condition,
            CancellationToken cancellationToken = default(CancellationToken), 
            bool asNoTracking = true, Including including = null);

        public void SaveChanges();

        public delegate IQueryable<TEntity> Including(IQueryable<TEntity> databaseContent);

    }
}