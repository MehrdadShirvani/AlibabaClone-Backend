using System.Linq.Expressions;

namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
    public interface IRepository<T_Entity, U_PrimaryKey> where T_Entity : class
    {
        Task<T_Entity?> GetByIdAsync(U_PrimaryKey id); 
        Task<IEnumerable<T_Entity>> GetAllAsync();
        Task<IEnumerable<T_Entity>> FindAsync(Expression<Func<T_Entity, bool>> predicate);
        Task AddAsync(T_Entity entity);
        void Update(T_Entity entity);
        void Remove(T_Entity entity);
    }
}
