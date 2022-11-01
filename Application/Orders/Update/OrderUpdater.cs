using Application.Orders.Find;
using Domain.Orders;
using Domain.Orders.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Update
{
    public class OrderUpdater
    {
        private readonly IOrderRepository repository;
        private readonly OrderFinder finder;

        public OrderUpdater(IOrderRepository repository, OrderFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(OrderUpdaterRequest request)
        {
            Order order = await finder.ExecuteAsync(new OrderFinderRequest(request.Id));
            switch (request.Status)
            {
                case OrderStatus.PendingVehicle:
                    order.Update(null, request.Status);
                    break;
                case OrderStatus.Delivered:
                    order.Update(null, request.Status);
                    break;
                case OrderStatus.InProcess:
                    order.Update(request.VehicleId, request.Status);
                    break;
                default:
                    throw new OrderStatusBadUse();
            }
            await repository.Update();
        }
    }
}
