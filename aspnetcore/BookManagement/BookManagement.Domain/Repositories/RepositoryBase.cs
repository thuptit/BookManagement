using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BookManagementDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(BookManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity Insert(TEntity entity)
        {
            var newEntity = _dbSet.Add(entity);
            _context.SaveChanges();
            return newEntity.Entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var newEntity = _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var newEntity = _dbSet.Update(entity);
            _context.SaveChanges();
            return newEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var newEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}
