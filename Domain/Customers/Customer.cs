using Domain.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int TelephoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(string name, int telephoneNumber, string address)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.TelephoneNumber = telephoneNumber;
            this.Address = address;
        }
    }
}
