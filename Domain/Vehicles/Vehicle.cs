using Domain.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vehicles
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        [Required]
        public string NumberPlate { get; set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }

        public Vehicle(string numberPlate, Guid driverId)
        {
            this.Id = Guid.NewGuid();
            this.NumberPlate = numberPlate;
            this.DriverId = driverId;
        }
    }
}
