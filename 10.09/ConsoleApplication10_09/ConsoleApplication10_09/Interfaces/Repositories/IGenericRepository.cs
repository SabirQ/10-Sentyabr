using ConsoleApplication10_09.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> func=null);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(Expression<Func<T, bool>> func=null);

    }
}
