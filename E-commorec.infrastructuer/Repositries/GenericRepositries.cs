using E_commorec.infrastructuer.Data;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.infrastructuer.Repositries
{
    public class GenericRepositries<T> : IGenericRepositry<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly IFileProvider fileProvider;

        public GenericRepositries(AppDbContext context)
        {
            this.context = context;
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


        public async Task UpdateAsync(int id, T entity)
        {
            var entities = await context.Set<T>().FindAsync(id);
            context.Update(entities);
            await context.SaveChangesAsync();
        }
    }
}
