using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.Domain.Abstraction
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets the created on date and time in UTC format.
        /// </summary>
        DateTime CreatedOnUtc { get; }
        /// <summary>
        /// Gets the modified on date and time in UTC format.
        /// </summary>
        DateTime? ModifiedOnUtc { get; }
    }    
}
