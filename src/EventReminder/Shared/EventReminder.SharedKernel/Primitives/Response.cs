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

        /// <summary>
        /// Creates a new <see cref="Response{TValue}"/> with the specified nullable value and the specified error.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <param name="error">The error in case the value is null.</param>
        /// <returns>A new instance of <see cref="Response{TValue}"/> with the specified value or an error.</returns>
        public static Response<TValue> Create<TValue>(TValue value, FailResponse error)
            where TValue : class
            => value is null ? Failure<TValue>(error) : Success(value);

        /// <summary>
        /// Returns a failure <see cref="Result{TValue}"/> with the specified error.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="error">The error.</param>
        /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified error and failure flag set.</returns>
        /// <remarks>
        /// We're purposefully ignoring the nullable assignment here because the API will never allow it to be accessed.
        /// The value is accessed through a method that will throw an exception if the result is a failure result.
        /// </remarks>
        public static Response<TValue> Failure<TValue>(FailResponse error) => new Response<TValue>(default!, false, error);
    }

    /// <summary>
    /// Represents the result of some operation, with status information and possibly a value and an error.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    public class Response<TValue> : Response
    {
        private readonly TValue _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{TValueType}"/> class with the specified parameters.
        /// </summary>
        /// <param name="value">The result value.</param>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error.</param>
        protected internal Response(TValue data, bool isSuccess, FailResponse error)
            : base(isSuccess, error)
            => _data = data;

        public static implicit operator Response<TValue>(TValue data) => Success(data);

        public TValue Data => IsSuccess ? _data : default;
    }
}
