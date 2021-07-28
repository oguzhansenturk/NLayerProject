using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class Repository<TEntitiy> : IRepository<TEntitiy> where TEntitiy : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntitiy> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntitiy>();
        }

        public async Task AddAsync(TEntitiy entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeASync(IEnumerable<TEntitiy> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntitiy>> Where(Expression<Func<TEntitiy, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntitiy>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntitiy> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntitiy entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntitiy> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntitiy> SingleOrDefaultAsync(Expression<Func<TEntitiy, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntitiy Update(TEntitiy entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
