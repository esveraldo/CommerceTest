using CommerceTest.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.Data.Repositories.Contracts
{
    public interface IBaseRepository<T>  where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<T> PostAsync(T obj);
        Task<T> PutAsync(T obj);
        Task<T> DeleteAsync(Guid id);
    }
}
