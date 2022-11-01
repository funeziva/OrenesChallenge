using Domain.Orders;
using System.ComponentModel.DataAnnotations;


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

        public static Customer Create(string name, int telephoneNumber, string address)
        {
            return new Customer(name, telephoneNumber, address);
        }

        public void Update(string name, int telephoneNumber, string address)
        {
            this.Name = name;
            this.TelephoneNumber = telephoneNumber;
            this.Address = address;
        }
    }
}
