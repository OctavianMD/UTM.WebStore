using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Update(T entity)
        {
            _appDbContext.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(T entity)
        {
            _appDbContext.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
