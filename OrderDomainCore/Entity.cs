using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderDomainCore
{
    public abstract class Entity
    {
        //Domain Driven Design, gerçek dünyadaki iş modellerini herkesin anlayabileceği ortak bir dil(Ubiquitous Language) ile oluşturarak dijital dünyaya uyarlamak için yazılımların nasıl modellenmesi gerektiği konusunda bir felsefeyi savunur.
        //DDD’da önemli bir kavram olan Entity, kendini diğer nesnelere nazaran tekilleştirebilmek için bir kimliğe(Id) sahip olan nesnelerdir.
        private int? _requestedHashCode;

        private string _Id;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id
        {
            get => _Id;
            set => _Id = value;
        }

        public bool IsTransient()
        {
            return this.Id == default(string);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }
    }
}
