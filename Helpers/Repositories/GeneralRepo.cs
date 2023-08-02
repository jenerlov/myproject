using myproject.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace myproject.Helpers.Repositories
{
    public abstract class GeneralRepo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected GeneralRepo(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();

        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }
    }
}