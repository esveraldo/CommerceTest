namespace CommerceTest.Domain.Entities.Base
{
    public class Entity
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


    }
}
