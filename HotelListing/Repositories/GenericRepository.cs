using HotelListing.Data;
using HotelListing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelContext context;

        public GenericRepository(HotelContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
           await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;

        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await GetAsync(Id);
           
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var list = await context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> GetAsync(int? Id)
        {
            if (Id is null)
                return null;

            return await context.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync(T entity)
        {
           context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
