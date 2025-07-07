using AlibabaClone.Domain.Framework.Interfaces;

namespace AlibabaClone.Infrastructure.Framework.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
