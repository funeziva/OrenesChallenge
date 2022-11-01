using LinqKit;
using System.Linq.Expressions;

namespace Domain.UbicationHistories.Predicates
{
    public class UbicationHistorysPredicates
    {
        private readonly Guid? vehicleId;
        private readonly DateTime? date;

        public UbicationHistorysPredicates(Guid? VehicleId, DateTime? date)
        {
            vehicleId = VehicleId;
            this.date = date;
        }

        public Expression<Func<UbicationHistory, bool>> CreateExpression()
        {
            ExpressionStarter<UbicationHistory> predicate = PredicateBuilder.New<UbicationHistory>(true);

            if (vehicleId != null)
            {
                predicate = predicate.And(ubication => ubication.VehicleId == vehicleId);
            }

            if (date != null)
            {
                predicate = predicate.And(ubication => ubication.CreatedDate <= date);
            }

            return predicate;
        }
    }
}
