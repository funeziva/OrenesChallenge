using LinqKit;
using System.Linq.Expressions;


namespace Domain.Orders.Predicates
{
    public class OrdersPredicates
    {
        private readonly Guid? id;
        private readonly Guid? vehicleId;
        private readonly Guid? customerId;
        private readonly OrderStatus? status;

        public OrdersPredicates(Guid? Id, Guid? vehicleId, Guid? customerId, OrderStatus? status)
        {
            id = Id;
            this.vehicleId = vehicleId;
            this.customerId = customerId;
            this.status = status;
        }

        public Expression<Func<Order, bool>> CreateExpression()
        {
            ExpressionStarter<Order> predicate = PredicateBuilder.New<Order>(true);

            if (id != null)
            {
                predicate = predicate.And(order => order.Id == id);
            }

            if (vehicleId != null)
            {
                predicate = predicate.And(order => order.VehicleId == vehicleId);
            }

            if (customerId != null)
            {
                predicate = predicate.And(order => order.CustomerId == customerId);
            }
             
            if (status != null)
            {
                predicate = predicate.And(order => order.Status == status);
            }

            return predicate;
        }
    }
}