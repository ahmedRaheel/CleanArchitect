using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReminder.SharedKernel.Primitives
{   
    public sealed class FailResponse : ValueObject
    {
        private string _code;
        private string _description;

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
    }
}
