using LinqKit;
using System.Linq.Expressions;


namespace Domain.Drivers.Predicates
{
    public class DriversPredicates
    {
        private readonly Guid? id;
        private readonly string? name;
        private readonly int? telephoneNumber;

        public DriversPredicates(Guid? id, string? name, int? telephoneNumber)
        {
            this.id = id;
            this.name = name;
            this.telephoneNumber = telephoneNumber;
        }

        public Expression<Func<Driver, bool>> CreateExpression()
        {
            ExpressionStarter<Driver> predicate = PredicateBuilder.New<Driver>(true);

            if (id != null)
            {
                predicate = predicate.And(driver => driver.Id == id);
            }

            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(driver => driver.Name == name);
            }

            if (!string.IsNullOrEmpty(telephoneNumber.ToString()))
            {
                predicate = predicate.And(driver => driver.TelephoneNumber == telephoneNumber);
            }

            return predicate;
        }
    }
}
