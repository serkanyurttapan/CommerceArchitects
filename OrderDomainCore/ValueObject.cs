using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomainCore
{
    public abstract class ValueObject
    {

        //Value object, herhangi bir kimlik(Id) değeri olmayan ve böylece aynı değerlere sahip iki value object nesnesinin değersel açıdan aynı olarak kabul edilebilir olmasını sağlayan ve dolayısıyla birbirlerinin yerine geçebilecekleri anlamına gelen bir nesnedir

        //ref:https://learn.microsoft.com/tr-tr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
