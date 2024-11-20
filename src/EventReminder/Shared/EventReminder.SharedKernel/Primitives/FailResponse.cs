using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.SharedKernel.Primitives
{
    /// <summary>
    /// Represents a concrete domain error.
    /// </summary>
    public sealed class FailResponse : ValueObject
    {
        private string _code;
        private string _description;

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        public FailResponse(string code, string description)
        {
            _code = code;
            _description = description;
        }

        public static implicit operator string(FailResponse error) => error?._code ?? string.Empty;
        /// <summary>
        /// Gets the empty error instance.
        /// </summary>
        internal static FailResponse None => new FailResponse(string.Empty, string.Empty);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _code;
            yield return _description;
        }
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }
    }
}
