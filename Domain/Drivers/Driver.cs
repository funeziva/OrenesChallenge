using Domain.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Domain.Drivers
{
    public class Driver
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TelephoneNumber { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public Driver(string name, int telephoneNumber)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.TelephoneNumber = telephoneNumber;
        }
    }
}
