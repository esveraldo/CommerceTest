using System.Collections;
using System.Linq.Expressions;

namespace CommerceTest.Domain.Entities.Base
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updatedAt;

        public DateTime UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }

        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}
