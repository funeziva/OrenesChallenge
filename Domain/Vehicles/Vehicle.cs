using Domain.Drivers;
using System.ComponentModel.DataAnnotations;

namespace Domain.Vehicles
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        [Required]
        public string NumberPlate { get; set; }
        [Required]
        public Guid DriverId { get; set; }
        [Required]
        public string Ubication { get; set; }
        public Driver Driver { get; set; }

        public Vehicle(string numberPlate, Guid driverId, string ubication)
        {
            this.Id = Guid.NewGuid();
            this.NumberPlate = numberPlate;
            this.DriverId = driverId;
            this.Ubication = ubication;
        }
    }
}
