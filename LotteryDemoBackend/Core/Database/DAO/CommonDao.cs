using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities.DAO;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.DAO
{
    public class CommonDao<TEntity> : ICommonDao<TEntity>
        where TEntity : class
    {
        public DbContext Context;

        public CommonDao(DbContext context)
        {
            Context = context;
        }

        #region ICommonDao

        public IEnumerable<TEntity> AddRangeItems(IEnumerable<TEntity> entities)
        {
            try
            {
                var table = GetTable();
                table.AddRange(entities);


                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while AddItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return entities;
        }

        public TEntity AddItem(TEntity entity)
        {
            try
            {
                var table = GetTable();
                table.Add(entity);


                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while AddItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return entity;
        }

        public async Task<TEntity> AddItemAsync(TEntity entity)
        {
            try
            {
                var table = GetTable();
                await table.AddAsync(entity);

                SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while AddItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return entity;
        }


        public IEnumerable<TEntity> UpdateRangeItems(IEnumerable<TEntity> entities)
        {
            try
            {
                var table = GetTable();

                table.UpdateRange(entities);

                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while UpdateItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return entities;
        }

        public TEntity UpdateItem(TEntity entity)
        {
            try
            {
                var table = GetTable();
                table.Update(entity);
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while UpdateItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return entity;
        }




        public Task<TEntity> UpdateItemAsync(TEntity entity)
        {
            try
            {
                var table = GetTable();

                table.Update(entity);

                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"An error occured while UpdateItem '{typeof(TEntity)}'. {ex.Message}",
                    ex.InnerException);
            }

            return Task.FromResult(entity);
        }
        


        public void DeleteRange(IEnumerable<TEntity> deleteList)
        {
            var list = deleteList as TEntity[] ?? deleteList.ToArray();
            if (!list.Any())
            {
                return;
            }

            foreach (var entity in list)
            {
                DeleteItem(entity);
            }
        }




      


        protected DbSet<TEntity> GetTable()
        {
            return Context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();


        }


        public void DeleteItem(TEntity item)
        {
            var table = GetTable();

            table.Remove(item);

            SaveChanges();
        }

        public TEntity GetSingle(Func<TEntity, bool> condition, 
            bool asNoTracking = true, ICommonDao<TEntity>.Including including = null)
        {
            try
            {
                var databaseContent = GetTable().Cast<TEntity>();
                if (including != null)
                {
                    databaseContent = including(databaseContent);
                }
                if (asNoTracking)
                    databaseContent = databaseContent.AsNoTracking();
                
                return !databaseContent.Any() ? null : databaseContent.ToList().FirstOrDefault(condition);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TEntity> GetCollection(Func<TEntity, bool> condition = null, bool asNoTracking = true, ICommonDao<TEntity>.Including including = null)
        {
            try
            {
                var databaseContent = GetTable().Cast<TEntity>();
                if (asNoTracking)
                    databaseContent = databaseContent.AsNoTracking();
                

                if (including != null)
                {
                    databaseContent = including(databaseContent);
                }
                if (!databaseContent.Any())
                {
                    return new List<TEntity>();
                }
                else
                {
                    return condition == null ? databaseContent.ToList() : databaseContent.ToList().Where(condition).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IQueryable<TEntity> GetCollectionIQueryable(Func<TEntity, bool> condition = null,  bool asNoTracking = true,
            ICommonDao<TEntity>.Including including = null)
        {
            try
            {
                var databaseContent = GetTable().Cast<TEntity>();
                if (asNoTracking)
                    databaseContent = databaseContent.AsNoTracking();
                

                if (including != null)
                {
                    databaseContent = including(databaseContent);
                }

                return condition == null ? databaseContent : databaseContent.Where(condition).AsQueryable();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default(CancellationToken),  bool asNoTracking = true, ICommonDao<TEntity>.Including including = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var databaseContent = GetTable().Cast<TEntity>();
                if (asNoTracking)
                    databaseContent = databaseContent.AsNoTracking();
                

                if (including != null)
                {
                    databaseContent = including(databaseContent);
                }
                if (!databaseContent.Any())
                {
                    return null;
                }
                else
                {
                    return await databaseContent.FirstOrDefaultAsync(condition, cancellationToken);
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool TestConnection()
        {
            return Context.Database.CanConnect();
        }

        public void Migrate()
        {
            try
            {
                Context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}
