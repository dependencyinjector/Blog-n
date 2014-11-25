using System;

namespace Blogn
{
    /// <summary>
    /// Code Contracts: Contains helper methods to enforce pre-conditions in code contracts.
    /// </summary>
    public static class Contract
    {
        /// <summary>
        /// Checks that a reference type parameter is not null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The value to be checked for null.</param>
        /// <param name="parameterName">The name of the parameter being checked which is used to customize the exception message.</param>
        /// <exception cref="ArgumentNullException">Thrown if the parameter being tested is in fact null.</exception>
        public static void IsNotNull<T>(T parameter, string parameterName) where T : class
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Checks that a string is not empty.
        /// </summary>
        /// <param name="parameter">The string parameter to be checked.</param>
        /// <param name="parameterName">The name of the parameter being checked which is used to customize the exception message.</param>
        /// <exception cref="ArgumentException">Thrown if the parameter being tested is in fact empty.</exception>
        public static void IsNotEmpty(string parameter, string parameterName)
        {
            if (parameter.Length == 0)
            {
                throw new ArgumentException(string.Format("Parameter '{0}' cannot be empty.", parameterName ?? "Unknown Parameter (null)"));
            }
        }

        /// <summary>
        /// Checks that a string is not empty or contains only white space characters.
        /// </summary>
        /// <param name="parameter">The string parameter to be checked.</param>
        /// <param name="parameterName">The name of the parameter being checked which is used to customize the exception message.</param>
        /// <exception cref="ArgumentException">Thrown if the parameter being tested is in fact empty or white space only.</exception>
        public static void IsNotEmptyOrWhiteSpace(string parameter, string parameterName)
        {
            if (parameter.Trim().Length == 0)
            {
                throw new ArgumentException(string.Format("Parameter '{0}' cannot be empty or white space.", parameterName ?? "Unknown Parameter (null)"));
            }
        }

        /// <summary>
        /// Checks that a string is not null or empty.
        /// </summary>
        /// <param name="parameter">The string parameter to be checked.</param>
        /// <param name="parameterName">The name of the parameter being checked which is used to customize the exception message.</param>
        /// <exception cref="ArgumentException">Thrown if the parameter being tested is in fact empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the parameter being tested is in fact null.</exception>
        public static void IsNotNullOrEmpty(string parameter, string parameterName)
        {
            IsNotNull(parameter, parameterName);
            IsNotEmpty(parameter, parameterName);
        }

        /// <summary>
        /// Checks that a string is not null or empty or contains only white space characters.
        /// </summary>
        /// <param name="parameter">The string parameter to be checked.</param>
        /// <param name="parameterName">The name of the parameter being checked which is used to customize the exception message.</param>
        /// <exception cref="ArgumentException">Thrown if the parameter being tested is in fact empty or contains only white space characters.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the parameter being tested is in fact null.</exception>
        public static void IsNotNullOrWhiteSpace(string parameter, string parameterName)
        {
            IsNotNull(parameter, parameterName);
            IsNotEmptyOrWhiteSpace(parameter, parameterName);
        }

        /// <summary>
        /// Checks that a given parameter is greater than the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be greater than expected.</param>
        /// <param name="expected">The value that the parameter must be greater than.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not greater than the expected value.</exception>
        public static void IsGreaterThan<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter is greater than or equal to the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be greater than or equal to expected.</param>
        /// <param name="expected">The value that the parameter must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not greater than or equal to the expected value.</exception>
        public static void IsGreaterThanOrEqualTo<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter is less than the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be less than expected.</param>
        /// <param name="expected">The value that the parameter must be less than.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not less than the expected value.</exception>
        public static void IsLessThan<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter is less than or equal to the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be less than or equal to expected.</param>
        /// <param name="expected">The value that the parameter must be less than or equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not less than or equal to the expected value.</exception>
        public static void IsLessThanOrEqualTo<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter is equal to the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be equal to expected.</param>
        /// <param name="expected">The value that the parameter must be equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not equal to the expected value.</exception>
        public static void IsEqualTo<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) != 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter is not equal to the expected value provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must not be equal to expected.</param>
        /// <param name="expected">The value that the parameter must not be equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is equal to the expected value.</exception>
        public static void IsNotEqualTo<T>(T parameter, T expected, string parameterName) where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(expected) == 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter's value is in the expected range provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be in the expected range.</param>
        /// <param name="start">The value that the parameter must be greater than or equal to.</param>
        /// <param name="end">The value that the parameter must be less than equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not in the specified range.</exception>
        public static void IsInRange<T>(T parameter, T start, T end, string parameterName)
            where T : struct, IComparable<T>
        {
            IsGreaterThanOrEqualTo(parameter, start, parameterName);
            IsLessThanOrEqualTo(parameter, end, parameterName);
        }

        /// <summary>
        /// Checks that a given parameter's value is in the expected range provided excluding the start and end points.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be in the expected range.</param>
        /// <param name="start">The value that the parameter must be greater than.</param>
        /// <param name="end">The value that the parameter must be less than.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is not in the specified range.</exception>
        public static void IsInRangeExclusive<T>(T parameter, T start, T end, string parameterName)
            where T : struct, IComparable<T>
        {
            IsGreaterThan(parameter, start, parameterName);
            IsLessThan(parameter, end, parameterName);
        }

        /// <summary>
        /// Checks that a given parameter's value is outside the expected range provided.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be outside the expected range.</param>
        /// <param name="start">The value that the parameter must be less than or equal to.</param>
        /// <param name="end">The value that the parameter must be greater than equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is in the specified range.</exception>
        public static void IsNotInRange<T>(T parameter, T start, T end, string parameterName)
            where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(start) >= 0 && parameter.CompareTo(end) <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Checks that a given parameter's value is outside the expected range provided excluding the start and end points.  Intended for numeric & date types.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to be checked.</typeparam>
        /// <param name="parameter">The parameter that must be in the expected range.</param>
        /// <param name="start">The value that the parameter must be less than or equal to.</param>
        /// <param name="end">The value that the parameter must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the parameter being checked.  (Used to customize exception messages.)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown is the value of the supplied parameter is in the specified range.</exception>
        public static void IsNotInRangeExclusive<T>(T parameter, T start, T end, string parameterName)
            where T : struct, IComparable<T>
        {
            if (parameter.CompareTo(start) > 0 && parameter.CompareTo(end) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName ?? "Unknown Parameter (null)");
            }
        }

        /// <summary>
        /// Generic pre-condition.  Allows developer specified, boolean conditions to be enforced.
        /// </summary>
        /// <param name="condition">A boolean condition that must be true.</param>
        /// <param name="message">A custom message for the exception that is thrown if the test fails.</param>
        /// <exception cref="ArgumentException">Thrown if the specified condition is false.</exception>
        /// <example>Contract.Requires(number1 / 2 > number2, "'number1' must be more than twice 'number2'."); </example>
        public static void Requires(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message ?? "The expected requirement was not met.");
            }
        }
    }
}
