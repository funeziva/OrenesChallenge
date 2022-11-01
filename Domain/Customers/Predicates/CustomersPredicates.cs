using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Predicates
{
    public class CustomersPredicates
    {
        private readonly Guid? id;
        private readonly string? name;
        private readonly int? telephoneNumber;
        private readonly string? address;

        public CustomersPredicates(Guid? id, string? name, int? telephoneNumber, string? address)
        {
            this.id = id;
            this.name = name;
            this.telephoneNumber = telephoneNumber;
            this.address = address;
        }

        public Expression<Func<Customer, bool>> CreateExpression()
        {
            ExpressionStarter<Customer> predicate = PredicateBuilder.New<Customer>(true);

            if (id != null)
            {
                predicate = predicate.And(customer => customer.Id == id);
            }

            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(customer => customer.Name == name);
            }

            if (!string.IsNullOrEmpty(telephoneNumber.ToString()))
            {
                predicate = predicate.And(customer => customer.TelephoneNumber == telephoneNumber);
            }

            if (!string.IsNullOrEmpty(address))
            {
                predicate = predicate.And(customer => customer.Address == address);
            }

            return predicate;
        }
    }
}
