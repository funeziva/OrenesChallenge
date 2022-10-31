using Domain.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.LocationHistorys
{
    public class UbicationHistory
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public string Ubication { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public Order Order { get; set; }

        public UbicationHistory(Guid orderId, string ubication)
        {
            this.OrderId = orderId;
            this.Ubication = ubication;
            this.CreatedDate = DateTime.Now;
        }
    }
}
