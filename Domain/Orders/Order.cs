using Domain.Customers;
using Domain.Vehicles;
using System.ComponentModel.DataAnnotations;


namespace Domain.Orders
{

    public enum OrderStatus
    {
        PendingVehicle,
        InProcess,
        Delivered
    }

    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public Guid? VehicleId { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }

        public Order(Guid customerId, Guid? vehicleId, OrderStatus status)
        {
            this.Id = Guid.NewGuid();
            this.CustomerId = customerId;
            this.VehicleId = vehicleId;
            this.Status = status;
        }

    }
}
