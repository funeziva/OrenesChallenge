using LinqKit;
using System.Linq.Expressions;

namespace Domain.Vehicles.Predicates
{
    public class VehiclesPredicates
    {
        private readonly Guid? id;
        private readonly string? ubication;
        private readonly string? numberPlate;
        private readonly Guid? driverId;

        public VehiclesPredicates(Guid? id, string? ubication, string? numberPlate, Guid? driverId)
        {
            this.id = id;
            this.ubication = ubication;
            this.numberPlate = numberPlate;
            this.driverId = driverId;
        }

        public Expression<Func<Vehicle, bool>> CreateExpression()
        {
            ExpressionStarter<Vehicle> predicate = PredicateBuilder.New<Vehicle>(true);

            if (id != null)
            {
                predicate = predicate.And(vehicle => vehicle.Id == id);
            }

            if (!string.IsNullOrEmpty(ubication))
            {
                predicate = predicate.And(vehicle => vehicle.Ubication == ubication);
            }

            if (!string.IsNullOrEmpty(numberPlate))
            {
                predicate = predicate.And(vehicle => vehicle.NumberPlate == numberPlate);
            }

            if(driverId != null)
            {
                predicate = predicate.And(vehicle => vehicle.DriverId == driverId);
            }

            return predicate;
        }
    }
}
