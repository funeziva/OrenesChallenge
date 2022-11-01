using System.Linq.Expressions;

namespace Domain.Vehicles
{
    public interface IVehicleRepository
    {
        Task Create(Vehicle vehicle);
        Task Update();
        Task<bool> Any(Expression<Func<Vehicle, bool>> expression);
        Task<Vehicle> Find(Expression<Func<Vehicle, bool>> expression);
        Task Delete(Vehicle vehicle);
        Task<List<Vehicle>> Search(Expression<Func<Vehicle, bool>> expression);
    }
}
