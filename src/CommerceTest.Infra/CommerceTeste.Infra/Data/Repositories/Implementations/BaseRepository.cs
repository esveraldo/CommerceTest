using CommerceTest.Domain.Entities.Base;
using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Data.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        public readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            var result = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return result.FirstOrDefault();
        }

        public virtual async Task<T> PostAsync(T obj)
        {
            _context.Entry<T>(obj).State = EntityState.Added;
            return obj;
        }

        public virtual async Task<T> PutAsync(T obj)
        {
            _context.Entry<T>(obj).State = EntityState.Modified;
            return obj;
        }

        public virtual async Task<T> DeleteAsync(Guid id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                _context.Entry<T>(obj).State = EntityState.Deleted;
            }
            return obj;
        }
    }
}
