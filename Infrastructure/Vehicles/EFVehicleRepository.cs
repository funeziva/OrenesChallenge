using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Vehicles
{
    public class EFVehicleRepository : IVehicleRepository
    {
        private readonly ApplicationContext context;

        public EFVehicleRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<bool> Any(Expression<Func<Vehicle, bool>> expression)
        {
            Vehicle vehicle = await context.Vehicles.FirstOrDefaultAsync(expression);
            return vehicle != null;
        }

        public async Task Create(Vehicle vehicle)
        {
            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
        }

        public async Task<Vehicle> Find(Expression<Func<Vehicle, bool>> expression)
        {
            return await context.Vehicles.FirstOrDefaultAsync(expression);
        }

        public async Task<List<Vehicle>> Search(Expression<Func<Vehicle, bool>> expression)
        {
            return await context.Vehicles.AsQueryable().Where(expression).ToListAsync();
        }

        public async Task Update()
        {
            await context.SaveChangesAsync();
        }
    }
}
