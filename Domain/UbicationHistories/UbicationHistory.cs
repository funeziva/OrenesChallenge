using Domain.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace Domain.UbicationHistories
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
            VehicleId = vehicleId;
            Ubication = ubication;
            CreatedDate = DateTime.Now;
        }
    }
}
