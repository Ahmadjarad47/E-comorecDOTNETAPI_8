using System.Linq.Expressions;

namespace E_commorec.core.InterFace
{
    public interface IGenericRepositry<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        Task<T> GetByGUIDAsync(Guid id);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteByGuidAsync(Guid id);
        Task<int> CountAsync();
        Task AddToMemoryCache(string KeyName, List<T> entity);
        Task DeleteFromMemoryCache(string KeyName);
        Task<IReadOnlyList<T>> GetAllFromMemoryAsync(string keyName);
    }
}
