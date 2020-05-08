using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Common.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class 
    {
        private readonly DbContext _context;

        protected DbSet<T> DbSet { get; set; }

        protected RepositoryBase(DbContext context)
        {
            _context = context;

            DbSet = _context.Set<T>();
        }

        protected IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }
    }
}
