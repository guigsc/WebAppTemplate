using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WebAppTemplate.Domain
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        protected Entity() { }

        protected Entity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }



    }
}
