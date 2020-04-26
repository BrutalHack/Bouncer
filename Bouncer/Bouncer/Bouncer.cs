using System;
using System.Collections;
using System.Linq;
using BrutalHack.Bouncer.Exceptions;

#pragma warning disable 659

namespace BrutalHack.Bouncer
{
    public partial class Bouncer : IBouncer
    {
        public const float Epsilon = 0.0001f;

        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void IsNotNull(params object[] values)
        {
            // if single input parameter is null, values is null.
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            for (var index = 0; index < values.Length; index++)
            {
                if (values[index] == null)
                {
                    throw new ArgumentNullException($"Parameter #{index} (Starting at 0)");
                }
            }
        }

        [Obsolete("IsNotEmpty is deprecated, please use IsNotNullOrEmpty instead.", false)]
        public void IsNotEmpty(ICollection collection)
        {
            IsNotNullOrEmpty(collection);
        }

        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        public void IsNotNullOrEmpty(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (collection.Count == 0)
            {
                throw new ArgumentEmptyException();
            }
        }

        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        public void IsEmpty(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (collection.Count > 0)
            {
                throw new ArgumentNotEmptyException();
            }
        }

        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        public void IsNotNullOrEmpty(params string[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            for (var index = 0; index < values.Length; index++)
            {
                if (values[index] == null)
                {
                    throw new ArgumentNullException($"Parameter #{index} (Starting at 0)");
                }

                if (string.IsNullOrEmpty(values[index]))
                {
                    throw new ArgumentEmptyException($"Parameter #{index} (Starting at 0)");
                }
            }
        }

        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        public void IsNotNullOrWhiteSpace(params string[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            for (var index = 0; index < values.Length; index++)
            {
                if (values[index] == null)
                {
                    throw new ArgumentNullException($"Parameter #{index} (Starting at 0)");
                }

                if (string.IsNullOrWhiteSpace(values[index]))
                {
                    throw new ArgumentEmptyException($"Parameter #{index} (Starting at 0)");
                }
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsPositive(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"Value must be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsPositive(float value)
        {
            if (value <= 0f)
            {
                throw new ArgumentOutOfRangeException($"Value must be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNegative(int value)
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException($"Value must be negative! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNegative(float value)
        {
            if (value >= 0f)
            {
                throw new ArgumentOutOfRangeException($"Value must be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsPositiveOrZero(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be negative! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsPositiveOrZero(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be negative! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNegativeOrZero(int value)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNegativeOrZero(float value)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be positive! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNotZero(int value)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException($"Value can't be zero! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsNotZero(float value)
        {
            if (Epsilon > value && value > -Epsilon)
            {
                throw new ArgumentOutOfRangeException($"Value can't be zero! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsTrue(bool value)
        {
            if (!value)
            {
                throw new ArgumentOutOfRangeException($"Value must be true! Current: {false}");
            }
        }

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsFalse(bool value)
        {
            if (value)
            {
                throw new ArgumentOutOfRangeException($"Value must be false! Current: {true}");
            }
        }

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsWithinRange(int min, int max, int value)
        {
            if (min > max)
            {
                throw new InvalidOperationException("Invalid boundaries for the closed interval: ({min}, {max})");
            }

            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value must be in range min: {min} max: {max}! Current: {value}");
            }
        }

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsWithinRange(float min, float max, float value)
        {
            if (min > max)
            {
                throw new InvalidOperationException("Invalid boundaries for the closed interval: ({min}, {max})");
            }

            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value must be in range min: {min} max: {max}! Current: {value}");
            }
        }

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsWithinRangeExcludingBoundaries(float min, float max, float value)
        {
            if (min > max)
            {
                throw new InvalidOperationException("Invalid boundaries for the open interval: ({min}, {max})");
            }

            if (value <= min || value >= max)
            {
                throw new ArgumentOutOfRangeException(
                    $"Value must be in range min: {min} max: {max}! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <param name="expectedValues"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Contains(int[] expectedValues, int value)
        {
            if (expectedValues.Length == 0)
            {
                throw new InvalidOperationException("No expected values given.");
            }

            if (!expectedValues.Contains(value))
            {
                var joinedExpectedValues = string.Join(", ", expectedValues);
                throw new ArgumentOutOfRangeException($"Expected values are: {joinedExpectedValues}! Current: {value}");
            }
        }

        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsGreaterOrEqual(int value, int other)
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
        public void IsGreater(int value, int other)
        {
            if (value <= other)
            {
                throw new ArgumentOutOfRangeException($"Value must be > other. Current value: {value}, other: {other}");
            }
        }
    }
}