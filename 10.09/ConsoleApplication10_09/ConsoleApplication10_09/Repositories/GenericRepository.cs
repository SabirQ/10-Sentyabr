using ConsoleApplication10_09.DAL;
using ConsoleApplication10_09.Interfaces.Repositories;
using ConsoleApplication10_09.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> func=null)
        {
            if (func==null) return await _context.Set<T>().ToListAsync();
            return await _context.Set<T>().Where(func).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id== id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(Expression<Func<T, bool>> func=null)
        {
            _context.RemoveRange(func);
            await _context.SaveChangesAsync();
        }
    }
}
