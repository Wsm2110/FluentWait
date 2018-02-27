using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2sc.Specialised.Domain.FireSupport.Tests.AutomatedTests.Utilities
{
    public static class ExpectedConditions
    {

        private static readonly double _maximumDifferenceAllowed = 0.01;

        /// <summary>
        /// Asserts the double.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Func<bool> AssertDouble(double initialValue, double value)
        {
            return () => Math.Abs(initialValue - value) < _maximumDifferenceAllowed;
        }

        /// <summary>
        /// Asserts the double.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Func<bool> AssertString(string initialValue, string value)
        {
            return () => initialValue.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1;
        }

        /// <summary>
        /// Asserts the double.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Func<bool> AssertBool(bool initialValue, bool value)
        {
            return () => initialValue == value;
        }
    }
}
