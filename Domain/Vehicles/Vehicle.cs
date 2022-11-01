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

        public Vehicle(string ubication, string numberPlate, Guid driverId)
        {
            this.Id = Guid.NewGuid();
            this.NumberPlate = numberPlate;
            this.DriverId = driverId;
            this.Ubication = ubication;
        }

        public static Vehicle Create(string ubication, string numberPlate, Guid driverId)
        {
            return new Vehicle(ubication, numberPlate, driverId);
        }

        public void UpdateNumberPlate(string numberPlate)
        {
            this.NumberPlate = numberPlate;
        }

        public void UpdateUbication(string ubication)
        {
            this.Ubication = ubication;
        }
    }
}
