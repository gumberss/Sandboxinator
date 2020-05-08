using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Common.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class 
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(DbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();
        }

        protected IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }
    }
}
