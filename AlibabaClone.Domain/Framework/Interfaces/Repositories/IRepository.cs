namespace AlibabaClone.Domain.Framework.Interfaces.Repositories
{
    public interface IRepository<T_Entity, U_PrimaryKey> where T_Entity : class
    {
        Task InsertAsync(T_Entity entity);
        Task DeleteAsync(U_PrimaryKey id);
        Task DeleteAsync(T_Entity entity);
        Task<List<T_Entity>> SelectAsync();
        Task<T_Entity> FindByIdAsync(U_PrimaryKey id);
        void Update(T_Entity entity);
        void Remove(T_Entity entity);
    }
}
