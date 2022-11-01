using System.Linq.Expressions;

namespace Domain.Drivers
{
    public interface IDriverRepository
    {
        Task Create(Driver driver);
        Task Update();
        Task<bool> Any(Expression<Func<Driver, bool>> expression);
        Task<Driver> Find(Expression<Func<Driver, bool>> expression);
        Task Delete(Driver driver);
        Task<List<Driver>> Search(Expression<Func<Driver, bool>> expression);
    }
}
