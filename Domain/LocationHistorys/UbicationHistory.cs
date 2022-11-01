using Domain.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Domain.LocationHistorys
{
    public class UbicationHistory
    {
        [Required]
        public Guid VehicleId { get; set; }
        [Required]
        public string Ubication { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public Vehicle Vehicle { get; set; }

        public UbicationHistory(Guid vehicleId, string ubication)
        {
            this.VehicleId = vehicleId;
            this.Ubication = ubication;
            this.CreatedDate = DateTime.Now;
        }
    }
}
