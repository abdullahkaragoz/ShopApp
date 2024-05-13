using ShopApp.Order.Application.Interfaces;
using ShopApp.Order.Persistence.Context;

namespace ShopApp.Order.Persistence.Repositories
{
    public class Repository : IRepository<T> where T : class
    {
        private readonly OrderContext context;

        public Repository(OrderContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
