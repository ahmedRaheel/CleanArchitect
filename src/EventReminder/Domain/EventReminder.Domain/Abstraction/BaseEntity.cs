using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Abstraction
{
    /// <summary>
    /// Base class for Entity models
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>
    {
        public TId Id { get; set; }

        protected BaseEntity(TId id) :base()
        {
            Id = id;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected BaseEntity() 
        {
        }

        public bool Equals(BaseEntity<TId> other)
        {
            throw new NotImplementedException();
        }
    }
}
