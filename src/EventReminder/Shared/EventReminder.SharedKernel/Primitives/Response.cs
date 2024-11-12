using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventReminder.SharedKernel.Primitives
{
    public class Response
    {
        public bool IsSuccess { get; }
        public FailResponse Error { get;}

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class with the specified parameters.
        /// </summary>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error.</param>
        protected Response(bool isSuccess, FailResponse error)
        {
            if (isSuccess && error != FailResponse.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == FailResponse.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        /// <summary>
        /// Returns a success <see cref="Response"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="Response"/> with the success flag set.</returns>
        public static Response Success() => new Response(true, FailResponse.None);

        /// <summary>
        /// Returns a success <see cref="Response{TValue}"/> with the specified value.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <returns>A new instance of <see cref="Response{TValue}"/> with the success flag set.</returns>
        public static Response<TValue> Success<TValue>(TValue value) => new Response<TValue>(value, true, FailResponse.None);

        /// <summary>
        /// Returns a failure <see cref="Response"/> with the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>A new instance of <see cref="Response"/> with the specified error and failure flag set.</returns>
        public static Response Failure(FailResponse error) => new Response(false, error);
    }

    /// <summary>
    /// Represents the result of some operation, with status information and possibly a value and an error.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    public class Response<TValue> : Response
    {
        private readonly TValue _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TValueType}"/> class with the specified parameters.
        /// </summary>
        /// <param name="value">The result value.</param>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error.</param>
        protected internal Response(TValue value, bool isSuccess, FailResponse error)
            : base(isSuccess, error)
            => _value = value;

        public static implicit operator Response<TValue>(TValue value) => Success(value);

        /// <summary>
        /// Gets the result value if the result is successful, otherwise throws an exception.
        /// </summary>
        /// <returns>The result value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure"/> is true.</exception>
        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    }
}
