using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.SharedKernel.Primitives
{
    /// <summary>
    /// Represent Result 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Result<T> : IEquatable<Result<T>>
    {
        private readonly T _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="data">The value.</param>
        private Result(T value) => _data = value;

        /// <summary>
        /// Gets a value indicating whether or not the value exists.
        /// </summary>
        public bool HasValue => _data is not null;
        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Data => HasValue ? _data : default;

        /// <summary>
        /// Creates a new <see cref="Result{T}"/> instance based on the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The new <see cref="Result{T}"/> instance.</returns>
        public static Result<T> GetResult(T value) => new(value);

        public static implicit operator Result<T>(T value) => GetResult(value);

        public static implicit operator T(Result<T> result) => result.Data;

        /// <inheritdoc />
        public bool Equals(Result<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (!HasValue && !other.HasValue)
            {
                return true;
            }

            if (!HasValue || !other.HasValue)
            {
                return false;
            }

            return Data.Equals(other.Data);
        }

        /// <inheritdoc />
        public override bool Equals(object obj) =>
            obj switch
            {
                null => false,
                T value => Equals(new Result<T>(value)),
                Result<T> result => Equals(result),
                _ => false
            };

        /// <inheritdoc />
        public override int GetHashCode() => HasValue ? Data.GetHashCode() : 0;
    }
}
