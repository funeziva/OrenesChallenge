using Domain.Drivers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Drivers
{
    public class EFDriverRepository : IDriverRepository
    {

        private readonly ApplicationContext context;

        public EFDriverRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> Any(Expression<Func<Driver, bool>> expression)
        {
            Driver driver= await context.Drivers.FirstOrDefaultAsync(expression);
            return driver != null;
        }

        public async Task Create(Driver driver)
        {
            await context.Drivers.AddAsync(driver);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Driver driver)
        {
            context.Drivers.Remove(driver);
            await context.SaveChangesAsync();
        }

        public async Task<Driver> Find(Expression<Func<Driver, bool>> expression)
        {
            return await context.Drivers.FirstOrDefaultAsync(expression);
        }

        public async Task<List<Driver>> Search(Expression<Func<Driver, bool>> expression)
        {
            return await context.Drivers.AsQueryable().Where(expression).ToListAsync();
        }

        public async Task Update()
        {
            await context.SaveChangesAsync();
        }
    }
}
