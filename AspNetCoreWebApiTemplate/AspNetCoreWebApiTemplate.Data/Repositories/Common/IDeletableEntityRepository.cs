namespace AspNetCoreWebApiTemplate.Data.Repositories.Common
{
    using Models.Common;

    using System.Linq;
    using System.Threading.Tasks;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllWithDeletedAsNoTracking();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        void UnDelete(TEntity entity);
    }
}
