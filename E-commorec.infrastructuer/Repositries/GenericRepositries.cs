using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using System.Linq.Expressions;

namespace E_commorec.infrastructuer.Repositries
{
    public class GenericRepositries<T> : IGenericRepositry<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly IFileProvider fileProvider;
        private readonly IMemoryCache memoryCache;
        public GenericRepositries(AppDbContext context, IMemoryCache memoryCache)
        {
            this.context = context;
            this.memoryCache = memoryCache;
        }

        public GenericRepositries(AppDbContext context, IFileProvider fileProvider)
        {
            this.context = context;
            this.fileProvider = fileProvider;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }




        public async Task<int> CountAsync()
        => await context.Set<T>().CountAsync();

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        => context.Set<T>().AsNoTracking().ToList();



        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
       => await context.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();

            // Apply includes
            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            // Filter by Id
            var entity = await query.FirstOrDefaultAsync(x => GetId(x) == id);
            return entity;
        }

        // Helper method to extract the Id property dynamically
        private int GetId(T entity)
        {
            // Replace this with the actual property name for the Id
            // Example: return entity.Id;
            throw new NotImplementedException("Implement GetId method based on your entity structure.");
        }


        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<T> GetByGUIDAsync(Guid id)
        => await context.Set<T>().FindAsync(id);

        public async Task DeleteByGuidAsync(Guid id)
        {
            var entities = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entities);
            await context.SaveChangesAsync();
        }

        public Task AddToMemoryCache(string KeyName, List<T> entity)
        {
            var entities = memoryCache.Set<List<T>>(KeyName, entity, DateTime.Now.AddHours(10));
            return Task.CompletedTask;
        }
        public async Task<IReadOnlyList<T>> GetAllFromMemoryAsync(string keyName)
        {
            if (memoryCache.TryGetValue(keyName, out List<T> cachedList))
            {
                return cachedList.AsReadOnly();
            }
            return new List<T>().AsReadOnly();
        }


        public Task DeleteFromMemoryCache(string KeyName)
        {
            memoryCache.Remove(KeyName);
            return Task.CompletedTask;
        }


    }
}
