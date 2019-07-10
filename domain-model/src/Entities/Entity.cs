namespace Emerging.Account.DomainModel.Entities
{
    using System;

    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the default value.", nameof(id));
            }

            Id = id;
        }

        public TId Id { get; }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;
            return Equals(entity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            return other != null && Id.Equals(other.Id);
        }
    }
}
