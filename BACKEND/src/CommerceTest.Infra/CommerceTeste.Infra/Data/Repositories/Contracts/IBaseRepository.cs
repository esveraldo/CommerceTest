using CommerceTest.Domain.Entities.Base;

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
