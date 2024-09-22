using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            
        }

        public Task SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public async Task<TEntity> GetByEmailAsync(string email)
        {
            return await _context.Set<TEntity>()
                                 .FirstOrDefaultAsync(entity => EF.Property<string>(entity, "Email") == email);
        }

      
    }
}

