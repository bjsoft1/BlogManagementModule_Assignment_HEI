
using BlogManagementModule.Database;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace BlogManagementModule.Services.Databse
{
    /// <summary>
    ///  NOTE From BijayAdhikari: This Both Class I already have. this class all code I copy and Pest here.
    ///  This Code Main Source Comes From `ABP Frameworks`. This is Powerfull frameworks for .net core
    ///  more information: https://abp.io/
    /// </summary>
    public interface IGenericRepository<EntityClass> where EntityClass : class
    {
        DatabaseConfiguration Database();
        Task<List<EntityClass>>? GetAsync(Expression<Func<EntityClass, bool>>? filter = null, Func<IQueryable<EntityClass>, IOrderedQueryable<EntityClass>>? orderBy = null, CancellationToken cancellationToken = default, bool trackable = true);
        List<EntityClass>? Get(Expression<Func<EntityClass, bool>>? filter = null, Func<IQueryable<EntityClass>, IOrderedQueryable<EntityClass>>? orderBy = null, bool trackable = true);
        EntityClass? Get(object id);
        Task<EntityClass?> GetAsync(object id);
        EntityClass? Get(int id);
        Task<EntityClass?> GetAsync(int id);
        EntityClass? Get(long id);
        Task<EntityClass?> GetAsync(long id);
        Task<bool> SaveChangeAsync();
        bool SaveChange();
        bool Delete(object id, bool autoSave = false);
        bool Delete(EntityClass entityModel, bool autoSave = false);
        bool Delete(List<EntityClass> entityModels, bool autoSave = false);
        EntityClass Update(EntityClass entityModel, bool autoSave = false);
        bool UpdateRange(List<EntityClass> entityModel, bool autoSave = false);
        bool DetachEntities(EntityClass entityModel);
        bool DetachEntities(List<EntityClass> entityModel);
        EntityClass Insert([NotNull] EntityClass entityModel, bool autoSave = false);
        Task<EntityClass> InsertAsync([NotNull] EntityClass entityModel, bool autoSave = false);
        IQueryable<EntityClass> WithDetails();
        IQueryable<EntityClass> WithDetails(params Expression<Func<EntityClass, object>>[] propertySelectors);
        string GetQueryableString();
        string GetQueryableString(params Expression<Func<EntityClass, object>>[] propertySelectors);
    }
}
