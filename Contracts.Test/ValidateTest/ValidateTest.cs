using System;
using System.Collections;
using System.Collections.Generic;
using BrutalHack.Contracts;
using BrutalHack.Contracts.Exceptions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Contracts.Test.ValidateTest
{
    [TestFixture]
    public partial class ValidateTest
    {
        [TestFixture]
        public class IsNotNull
        {
            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Validate.IsNotNull(null));
            }

            [Test]
            [TestCase(3)]
            [TestCase(10f)]
            [TestCase("hello")]
            [TestCase(typeof(Guid))]
            public void NotNull_ThenDoNothing(object value)
            {
                Assert.DoesNotThrow(() => Validate.IsNotNull(value));
            }
        }

        [TestFixture]
        public class IsPositive
        {
            [Test]
            public void IsZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositive(0));
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositive(0f));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-7)]
            [TestCase(int.MinValue)]
            public void IsNegativeInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositive(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-271f)]
            [TestCase(float.MinValue)]
            [TestCase(-0.000000000001f)]
            public void IsNegativeFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositive(value));
            }

            [Test]
            [TestCase(1)]
            [TestCase(84)]
            [TestCase(int.MaxValue)]
            public void IsPositiveOrZeroInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => Validate.IsPositive(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(0.0000000000000001f)]
            [TestCase(4932f)]
            [TestCase(float.MaxValue)]
            public void IsPositiveOrZeroFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => Validate.IsPositive(value));
            }
        }

        [TestFixture]
        public class IsPositiveOrZero
        {
            [Test]
            public void IsZero_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => Validate.IsPositiveOrZero(0));
                Assert.DoesNotThrow(() => Validate.IsPositiveOrZero(0f));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-7)]
            [TestCase(int.MinValue)]
            public void IsNegativeInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositiveOrZero(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-271f)]
            [TestCase(float.MinValue)]
            [TestCase(-0.000000000001f)]
            public void IsNegativeFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPositiveOrZero(value));
            }


            [Test]
            [TestCase(1)]
            [TestCase(84)]
            [TestCase(int.MaxValue)]
            public void IsPositiveInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => Validate.IsPositiveOrZero(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(0.0000000000000001f)]
            [TestCase(4932f)]
            [TestCase(float.MaxValue)]
            public void IsPositiveFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => Validate.IsPositiveOrZero(value));
            }
        }

        [TestFixture]
        public class IsNotEmpty
        {
            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Validate.IsNotEmpty(null));
            }

            [Test]
            [TestCaseSource(nameof(IsNotEmptyTestCaseData))]
            public void IsNotEmpty_ThenDoNothing(ICollection value)
            {
                Assert.DoesNotThrow(() => Validate.IsNotEmpty(value));
            }

            private static IEnumerable<ICollection> IsNotEmptyTestCaseData
            {
                [UsedImplicitly]
                get
                {
                    var testCaseList = new List<ICollection>
                    {
                        new List<int> {1},
                        new Dictionary<int, string>
                        {
                            {0, "one"},
                            {219, "two"}
                        },
                        new SortedSet<float> {0f, 4f, 5f},
                        new[] {'a', 'd'},
                        new object[] {Guid.Empty, "hello", 4},
                        new Stack<int>(new[] {1, 4, 6, 3, 5, 6, 2, 234, 8})
                    };

                    foreach (var collection in testCaseList)
                    {
                        yield return collection;
                    }
                }
            }

            [Test]
            [TestCaseSource(nameof(IsEmptyTestCaseData))]
            public void IsEmpty_ThenThrowException(ICollection value)
            {
                Assert.Throws<ArgumentEmptyException>(() => Validate.IsNotEmpty(value));
            }

            private static IEnumerable<ICollection> IsEmptyTestCaseData
            {
                [UsedImplicitly]
                get
                {
                    var testCaseList = new List<ICollection>
                    {
                        new List<int>(),
                        new Dictionary<int, string>(),
                        new SortedSet<float>(),
                        new object[0],
                        new Stack<int>()
                    };

                    foreach (var collection in testCaseList)
                    {
                        yield return collection;
                    }
                }
            }
        }

        [TestFixture]
        public class IsInRange
        {
            [Test]
            [TestCase(0, 0, 0)]
            [TestCase(-1, -1, 0)]
            [TestCase(6, 6, 0)]
            [TestCase(0, 1, 0)]
            [TestCase(-1, 0, 0)]
            [TestCase(4223, 4224, 0)]
            [TestCase(-4223, -4224, 0)]
            [TestCase(4223, -4224, 0)]
            [TestCase(5, 2, 0)]
            public void InvalidBoundaries_ThenThrowException(int min, int max, int value)
            {
                Assert.Throws<InvalidOperationException>(() => Validate.IsInRange(min, max, value));
            }

            [Test]
            [TestCase(0, 2, 1)]
            [TestCase(-3, -1, -2)]
            [TestCase(-1, 1, 0)]
            [TestCase(-2324234, 2, 1)]
            [TestCase(-500, -100, -234)]
            [TestCase(3429434, int.MaxValue, int.MaxValue - 1)]
            public void IsInRangeInt_ThenDoNothing(int min, int max, int value)
            {
                Assert.DoesNotThrow(() => Validate.IsInRange(min, max, value));
            }

            [Test]
            [TestCase(0, 2, 8)]
            [TestCase(-3, -1, -7)]
            [TestCase(-1, 1, 5)]
            [TestCase(-2324234, 2, 456773)]
            [TestCase(-500, -100, 234)]
            [TestCase(3429434, int.MaxValue, 0)]
            public void IsNotInRangeInt_ThenDoNothing(int min, int max, int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsInRange(min, max, value));
            }
        }

        [TestFixture]
        public class IsPossibleValue
        {
            [Test]
            public void NoPossibleValues_ThenThrowException()
            {
                Assert.Throws<InvalidOperationException>(() => Validate.IsPossibleValue(new int[0], 5));
            }

            [Test]
            [TestCase(new[] {0}, 0)]
            [TestCase(new[] {-5}, -5)]
            [TestCase(new[] {8}, 8)]
            [TestCase(new[] {0, 1}, 1)]
            [TestCase(new[] {0, 1}, 0)]
            [TestCase(new[] {0, -5, 8, 13}, 8)]
            [TestCase(new[] {0, -5, 8, 13}, -5)]
            [TestCase(new[] {-1, 0, -1}, -1)]
            [TestCase(new[] {0, 0, 0, 0, 0}, 0)]
            public void IsPossibleValue_ThenDoNothing(int[] possibleValues, int value)
            {
                Assert.DoesNotThrow(() => Validate.IsPossibleValue(possibleValues, value));
            }

            [Test]
            [TestCase(new[] {0}, 1)]
            [TestCase(new[] {-5}, 5)]
            [TestCase(new[] {8}, 0)]
            [TestCase(new[] {0, 2}, 1)]
            [TestCase(new[] {0, 1}, 2)]
            [TestCase(new[] {0, -5, 8, 13}, 5)]
            [TestCase(new[] {0, 0, 0, 0, 0}, 1)]
            public void IsNotPossibleValue_ThenThrowException(int[] possibleValues, int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsPossibleValue(possibleValues, value));
            }
        }

        [TestFixture]
        public class IsGreater
        {
            [Test]
            [TestCase(1, 0)]
            [TestCase(-2, -10)]
            [TestCase(int.MaxValue, int.MinValue)]
            public void IsGreater_ThenDoNothing(int value, int other)
            {
                Assert.DoesNotThrow(() => Validate.IsGreater(value, other));
            }

            [Test]
            [TestCase(1, 2)]
            [TestCase(-11, -10)]
            [TestCase(int.MinValue, int.MaxValue)]
            public void IsNotGreater_ThenThrowException(int value, int other)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsGreater(value, other));
            }

            [Test]
            public void IsEqual_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsGreater(2, 2));
            }
        }
        
        [TestFixture]
        public class IsGreaterOrEqual
        {
            [Test]
            [TestCase(1, 0)]
            [TestCase(-2, -10)]
            [TestCase(int.MaxValue, int.MinValue)]
            public void IsGreater_ThenDoNothing(int value, int other)
            {
                Assert.DoesNotThrow(() => Validate.IsGreaterOrEqual(value, other));
            }

            [Test]
            [TestCase(1, 2)]
            [TestCase(-11, -10)]
            [TestCase(int.MinValue, int.MaxValue)]
            public void IsNotGreater_ThenThrowException(int value, int other)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Validate.IsGreaterOrEqual(value, other));
            }
            
            [Test]
            public void IsEqual_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => Validate.IsGreaterOrEqual(2, 2));
            }
        }
    }
}