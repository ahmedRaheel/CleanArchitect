﻿using EventReminder.SharedKernel.Primitives;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventReminder.Usecase.Core.Extensions
{
    /// <summary>
    /// Contains extension methods for fluent validations.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Specifies a custom error to use if validation fails.
        /// </summary>
        /// <typeparam name="T">The type being validated.</typeparam>
        /// <typeparam name="TProperty">The property being validated.</typeparam>
        /// <param name="rule">The current rule.</param>
        /// <param name="error">The error to use.</param>
        /// <returns>The same rule builder.</returns>
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, FailResponse error)
        {
            if (error is null)
            {
                throw new ArgumentNullException(nameof(error), "The error is required");
            }

            return rule.WithErrorCode(error.Code).WithMessage(error.Message);
        }
    }
}
