using System;
using System.Collections;
using System.Linq;
using BrutalHack.Contracts.Exceptions;

#pragma warning disable 659

namespace BrutalHack.Contracts
{
    public static class Validate
    {
        public const float Epsilon = 0.0001f;

        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNotNull(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        public static void IsNotEmpty(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (collection.Count <= 0)
            {
                throw new ArgumentEmptyException();
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsPositive(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"Value must be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsPositive(float value)
        {
            if (value <= 0f)
            {
                throw new ArgumentOutOfRangeException($"Value must be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsPositiveOrZero(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be negative! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsPositiveOrZero(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be negative! Current: {value}");
            }
        }

        /// <param name="expected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AreEqual(int expected, int value)
        {
            if (expected != value)
            {
                throw new ArgumentException($"Expected: {expected}, actual {value}.");
            }
        }

        public static void AreEqual(object expected, object value)
        {
            if (expected == null)
            {
                if (value != null)
                {
                    throw new ArgumentException($"Expected: {null}, actual {value}.");
                }

                return;
            }

            if (!expected.Equals(value))
            {
                throw new ArgumentException($"Expected: {expected}, actual {value}.");
            }
        }

        /// <param name="expected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AreEqual(float expected, float value, float epsilon = Epsilon)
        {
            if (Math.Abs(expected - value) > Epsilon)
            {
                throw new ArgumentException($"Expected: {expected}, actual {value}.");
            }
        }

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsInRange(int min, int max, int value)
        {
            if (min + 1 >= max)
            {
                throw new InvalidOperationException("Invalid boundaries for the open interval: ({min}, {max})");
            }
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value must be in range min: {min} max: {max}! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <param name="possibleValues"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsPossibleValue(int[] possibleValues, int value)
        {
            if (possibleValues.Length == 0)
            {
                throw new InvalidOperationException("No possible values given.");
            }
            if (!possibleValues.Contains(value))
            {
                throw new ArgumentOutOfRangeException($"Possible values are: {possibleValues}! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsGreaterOrEqual(int value, int other)
        {
            if (value < other)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value must be >= other. Current value: {value}, other: {other}");
            }
        }

        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsGreater(int value, int other)
        {
            if (value <= other)
            {
                throw new ArgumentOutOfRangeException($"Value must be > other. Current value: {value}, other: {other}");
            }
        }
    }
}