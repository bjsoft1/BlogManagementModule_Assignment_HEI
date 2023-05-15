using BlogManagementModule.Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace BlogManagementModule.Services.Databse
{
    public class GenericRepository<EntityClass> : IGenericRepository<EntityClass> where EntityClass : class
    {
        private readonly DatabaseConfiguration _databaseConfiguration;
        private DbSet<EntityClass> dbSet;
        public GenericRepository(DatabaseConfiguration databaseConfiguration)
        {
            this._databaseConfiguration = databaseConfiguration;
            this.dbSet = this._databaseConfiguration.Set<EntityClass>();
        }
        public virtual DatabaseConfiguration Database()
        {
            return this._databaseConfiguration;
        }
        public virtual List<EntityClass>? Get(Expression<Func<EntityClass, bool>>? filter = null, Func<IQueryable<EntityClass>, IOrderedQueryable<EntityClass>>? orderBy = null, bool trackable = true)
        {
            IQueryable<EntityClass> query = dbSet;
            if (filter != null)
            {
                query = trackable ? query.Where(filter).AsNoTracking() : query.Where(filter).AsNoTracking();
            }
            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }
        public virtual Task<List<EntityClass>>? GetAsync(Expression<Func<EntityClass, bool>>? filter = null, Func<IQueryable<EntityClass>, IOrderedQueryable<EntityClass>>? orderBy = null, CancellationToken cancellationToken = default, bool trackable = true)
        {
            IQueryable<EntityClass> query = dbSet;
            if (filter != null)
            {
                query = trackable ? query.Where(filter).AsNoTracking() : query.Where(filter).AsNoTracking();
            }
            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return query.AsNoTracking().ToListAsync();
            }
        }
        public virtual async Task<EntityClass?> GetAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual EntityClass? Get(object id)
        {
            return dbSet.Find(id);
        }
        public virtual EntityClass? Get(int id)
        {
            return dbSet.Find(id);
        }
        public virtual async Task<EntityClass?> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual EntityClass? Get(long id)
        {
            return dbSet.Find(id);
        }
        public virtual async Task<EntityClass?> GetAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }
        public EntityClass Insert([NotNull] EntityClass entity, bool autoSave = false)
        {
            var a = dbSet.Add(entity).Entity;
            if (autoSave)
            {
                _databaseConfiguration.SaveChanges();
            }
            return a;
        }
        public async Task<EntityClass> InsertAsync([NotNull] EntityClass entityModel, bool autoSave = false)
        {
            var a = dbSet.AddAsync(entityModel).Result.Entity;
            if (autoSave)
            {
                await this.SaveChangeAsync();
            }
            return a;
        }
        public virtual bool Delete(object Id, bool autoSave = false)
        {
            var a = dbSet.Find(Id);
            if (a == null)
                return false;
            Delete(a);
            if (autoSave)
            {
                return _databaseConfiguration.SaveChanges() > 0;
            }
            return true;
        }
        public virtual bool Delete(EntityClass entity, bool autoSave = false)
        {
            if (entity == null)
                return false;
            var a = dbSet.Remove(entity);
            if (autoSave)
            {
                return _databaseConfiguration.SaveChanges() > 0;
            }
            return true;
        }
        public virtual bool Delete(List<EntityClass> entityModels, bool autoSave = false)
        {
            if (entityModels == null || entityModels.Count == 0)
                return false;
            dbSet.RemoveRange(entityModels);
            if (autoSave)
            {
                return _databaseConfiguration.SaveChanges() > 0;
            }
            return true;
        }
        public virtual EntityClass Update([NotNull] EntityClass entityModel, bool autoSave = false)
        {
            var a = _databaseConfiguration.Update(entityModel).Entity;
            if (autoSave)
            {
                _databaseConfiguration.SaveChanges();
            }
            return a;
        }
        public bool UpdateRange([NotNull] List<EntityClass> entityModel, bool autoSave = false)
        {
            _databaseConfiguration.UpdateRange(entityModel);
            if (autoSave)
            {
                return _databaseConfiguration.SaveChanges() > 0;
            }
            return true;
        }
        public bool DetachEntities(EntityClass entityModel)
        {
            _databaseConfiguration.Entry(entityModel).State = EntityState.Detached;
            return true;
        }
        public bool DetachEntities(List<EntityClass> entityModel)
        {
            foreach (var _entity in entityModel)
            {
                _databaseConfiguration.Entry(_entity).State = EntityState.Detached;
            }
            return true;
        }
        public async Task<bool> SaveChangeAsync()
        {
            var a = await _databaseConfiguration.SaveChangesAsync();
            return a > 0;
        }
        public bool SaveChange()
        {
            var a = _databaseConfiguration.SaveChanges();
            return a > 0;
        }
        public IQueryable<EntityClass> WithDetails()
        {
            return GetQueryable();
        }
        public IQueryable<EntityClass> WithDetails(params Expression<Func<EntityClass, object>>[] propertySelectors)
        {
            return IncludeDetails(GetQueryable(), propertySelectors);
        }
        public string GetQueryableString()
        {
            return GetQueryable().ToQueryString();
        }
        public string GetQueryableString(params Expression<Func<EntityClass, object>>[] propertySelectors)
        {
            return IncludeDetails(GetQueryable(), propertySelectors).ToQueryString();
        }
        private bool disposed = false;
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _databaseConfiguration.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        #region Private Function
        private IQueryable<EntityClass> IncludeDetails(IQueryable<EntityClass> query, Expression<Func<EntityClass, object>>[] propertySelectors)
        {
            if (propertySelectors != null)
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }
            return query;
        }
        private IQueryable<EntityClass> GetQueryable()
        {
            var a = dbSet.AsQueryable();
            return a;
        }
        #endregion Private Function
    }
}
