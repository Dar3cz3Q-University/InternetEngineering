﻿namespace Core.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> one, Entity<TId> two)
        {
            return Equals(one, two);
        }

        public static bool operator !=(Entity<TId> one, Entity<TId> two)
        {
            return !Equals(one, two);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
