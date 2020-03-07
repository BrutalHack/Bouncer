using System;
using System.Collections;
using BrutalHack.Bouncer.Exceptions;

namespace BrutalHack.Bouncer
{
    public interface IBouncer
    {
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        void IsNotNull(params object[] values);

        [Obsolete("IsNotEmpty is deprecated, please use IsNotNullOrEmpty instead.", false)]
        void IsNotEmpty(ICollection collection);

        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        void IsNotNullOrEmpty(ICollection collection);

        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        void IsEmpty(ICollection collection);

        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        void IsNotNullOrEmpty(params string[] values);

        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentEmptyException"></exception>
        void IsNotNullOrWhiteSpace(params string[] values);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsPositive(int value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsPositive(float value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsNegative(int value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsNegative(float value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsPositiveOrZero(int value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsPositiveOrZero(float value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsNegativeOrZero(int value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsNegativeOrZero(float value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsTrue(bool value);

        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsFalse(bool value);

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsWithinRange(int min, int max, int value);

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsWithinRange(float min, float max, float value);

        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsWithinRangeExcludingBoundaries(float min, float max, float value);

        /// <param name="value"></param>
        /// <param name="expectedValues"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void Contains(int[] expectedValues, int value);

        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsGreaterOrEqual(int value, int other);

        /// <param name="value"></param>
        /// <param name="other"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        void IsGreater(int value, int other);

        /// <param name="notExpected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        void AreNotEqual(int notExpected, int value);

        void AreNotEqual(object notExpected, object value);

        /// <param name="notExpected"></param>
        /// <param name="value"></param>
        /// <param name="epsilon"></param>
        /// <exception cref="ArgumentException"></exception>
        void AreNotEqual(float notExpected, float value, float epsilon = Bouncer.Epsilon);

        /// <param name="expected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        void AreEqual(int expected, int value);

        void AreEqual(object expected, object value);

        /// <param name="expected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        void AreEqual(float expected, float value, float epsilon = Bouncer.Epsilon);
    }
}