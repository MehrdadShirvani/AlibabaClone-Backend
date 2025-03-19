using AlibabaClone.Domain.Framework.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Infrastructure.Framework.Base
{
    public class BaseRepository<K_DbContext, T_Entity, U_PrimaryKey> : IRepository<T_Entity, U_PrimaryKey>
                                                                          where T_Entity : class
                                                                          where K_DbContext : DbContext
    {
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<T_Entity> DBSet{ get; set; }
        
        public BaseRepository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DBSet = dbContext.Set<T_Entity>();
        }
        
        public async Task InsertAsync(T_Entity entity)
        {
            await DBSet.AddAsync(entity);
        }
        
        public async Task DeleteAsync(U_PrimaryKey id)
        {
            var entityToDelete = await DBSet.FindAsync(id);
            DBSet.Remove(entityToDelete);
        }
        public async Task DeleteAsync(T_Entity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DBSet.Attach(entityToDelete);
            }
            DBSet.Remove(entityToDelete);
        }
        public async Task<T_Entity> FindByIdAsync(U_PrimaryKey id)
        {
            return await DBSet.FindAsync(id);
        }
        public async Task<List<T_Entity>> SelectAsync()
        {
            var entityList = DBSet.ToListAsync();
            return await entityList;
        }
        public void Update(T_Entity entity)
        {
            DBSet.Update(entity);
        }
        public void Remove(T_Entity entity)
        {
            DBSet.Remove(entity);
        }
    }
}
