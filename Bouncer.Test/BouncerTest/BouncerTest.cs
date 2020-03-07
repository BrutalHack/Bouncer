using System;
using System.Collections;
using System.Collections.Generic;
using BrutalHack.Bouncer;
using BrutalHack.Bouncer.Exceptions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Bouncer.Test.BouncerTest
{
    [TestFixture]
    public partial class BouncerTest
    {
        [TestFixture]
        public class IsNotNull
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNull(null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNull(null, null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNull(null, null, null));
            }

            [Test]
            public void OneOfManyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNull(null, "hi"));
                try
                {
                    _bouncer.IsNotNull(null, "hi");
                }
                catch (ArgumentNullException e)
                {
                    StringAssert.Contains("Parameter #0", e.ParamName);
                }

                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNull("hi", 5, null));
                try
                {
                    _bouncer.IsNotNull("hi", 5, null);
                }
                catch (ArgumentNullException e)
                {
                    StringAssert.Contains("Parameter #2", e.ParamName);
                }
            }

            [Test]
            [TestCase(3)]
            [TestCase(10f)]
            [TestCase("hello")]
            [TestCase(typeof(Guid))]
            public void NotNull_ThenDoNothing(object value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNull(value));
            }

            [Test]
            [TestCase(3, 5, 8)]
            [TestCase(10f, 9f, 2f)]
            [TestCase("hello", "test", "data")]
            [TestCase(typeof(Guid), typeof(string), typeof(List))]
            [TestCase("hello", typeof(List), 5f)]
            public void NotNullParams_ThenDoNothing(object value1, object value2, object value3)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNull(value1, value2, value3));
            }
        }

        [TestFixture]
        public class IsNotNullOrEmptyOnValues
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null, null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null, null, null));
            }

            [Test]
            public void IsNullOrEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty(""));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty("", ""));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty("", "", ""));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty("", null, ""));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null, "", null));
            }

            [Test]
            public void OneOfManyIsNullOrEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null, "hi"));
                try
                {
                    _bouncer.IsNotNullOrEmpty(null, "hi");
                }
                catch (ArgumentNullException e)
                {
                    StringAssert.Contains("Parameter #0", e.ParamName);
                }

                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty("hi", "test", ""));
                try
                {
                    _bouncer.IsNotNullOrEmpty("hi", "test", "");
                }
                catch (ArgumentEmptyException e)
                {
                    StringAssert.Contains("Parameter #2", e.ParamName);
                }
            }

            [Test]
            [TestCase("hello")]
            [TestCase(".")]
            [TestCase(" ")]
            [TestCase("lorem ipsum dolor sit amet. lorem ipsum dolor sit amet. lorem ipsum dolor sit amet.  ")]
            public void NotNullOrEmpty_ThenDoNothing(string value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNullOrEmpty(value));
            }

            [Test]
            [TestCase("hello", "test", "data")]
            [TestCase(" ", " ", " ")]
            public void NotNullOrEmptyParams_ThenDoNothing(string value1, string value2, string value3)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNullOrEmpty(value1, value2, value3));
            }
        }

        [TestFixture]
        public class IsNotNullOrWhiteSpace
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null, null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null, null, null));
            }

            [Test]
            public void IsNullOrWhiteSpace_ThenThrowException()
            {
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace(""));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace(" "));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace("", ""));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace(" ", " "));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace("", null));
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace(" ", null));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null, ""));
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null, " "));
            }

            [Test]
            public void OneOfManyIsNullOrWhiteSpace_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrWhiteSpace(null, "hi"));
                try
                {
                    _bouncer.IsNotNullOrWhiteSpace(null, "hi");
                }
                catch (ArgumentNullException e)
                {
                    StringAssert.Contains("Parameter #0", e.ParamName);
                }

                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace("hi", "", "test"));
                try
                {
                    _bouncer.IsNotNullOrWhiteSpace("hi", "", "test");
                }
                catch (ArgumentEmptyException e)
                {
                    StringAssert.Contains("Parameter #1", e.ParamName);
                }

                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrWhiteSpace("hi", "test", " "));
                try
                {
                    _bouncer.IsNotNullOrWhiteSpace("hi", "test", " ");
                }
                catch (ArgumentEmptyException e)
                {
                    StringAssert.Contains("Parameter #2", e.ParamName);
                }
            }

            [Test]
            [TestCase("hello")]
            [TestCase(".")]
            [TestCase("lorem ipsum dolor sit amet. lorem ipsum dolor sit amet. lorem ipsum dolor sit amet.  ")]
            public void NotNullOrWhiteSpace_ThenDoNothing(string value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNullOrWhiteSpace(value));
            }

            [Test]
            [TestCase("hello", "test", "data")]
            [TestCase(".", ".", ".")]
            public void NotNullOrWhiteSpaceParams_ThenDoNothing(string value1, string value2, string value3)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNullOrWhiteSpace(value1, value2, value3));
            }
        }

        [TestFixture]
        public class IsTrue
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsFalse_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsTrue(false));
            }

            [Test]
            public void IsTrue_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.IsTrue(true));
            }
        }

        [TestFixture]
        public class IsFalse
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsTrue_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsFalse(true));
            }

            [Test]
            public void IsFalse_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.IsFalse(false));
            }
        }

        [TestFixture]
        public class IsPositive
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositive(0));
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositive(0f));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-7)]
            [TestCase(int.MinValue)]
            public void IsNegativeInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositive(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-271f)]
            [TestCase(float.MinValue)]
            [TestCase(-0.000000000001f)]
            public void IsNegativeFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositive(value));
            }

            [Test]
            [TestCase(1)]
            [TestCase(84)]
            [TestCase(int.MaxValue)]
            public void IsPositiveInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsPositive(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(0.0000000000000001f)]
            [TestCase(4932f)]
            [TestCase(float.MaxValue)]
            public void IsPositiveFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsPositive(value));
            }
        }

        [TestFixture]
        public class IsPositiveOrZero
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsZero_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.IsPositiveOrZero(0));
                Assert.DoesNotThrow(() => _bouncer.IsPositiveOrZero(0f));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-7)]
            [TestCase(int.MinValue)]
            public void IsNegativeInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositiveOrZero(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-271f)]
            [TestCase(float.MinValue)]
            [TestCase(-0.000000000001f)]
            public void IsNegativeFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsPositiveOrZero(value));
            }


            [Test]
            [TestCase(1)]
            [TestCase(84)]
            [TestCase(int.MaxValue)]
            public void IsPositiveInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsPositiveOrZero(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(0.0000000000000001f)]
            [TestCase(4932f)]
            [TestCase(float.MaxValue)]
            public void IsPositiveFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsPositiveOrZero(value));
            }
        }

        [TestFixture]
        public class IsNegative
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegative(0));
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegative(0f));
            }

            [Test]
            [TestCase(1)]
            [TestCase(7)]
            [TestCase(int.MaxValue)]
            public void IsPositiveInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegative(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(271f)]
            [TestCase(float.MaxValue)]
            [TestCase(0.000000000001f)]
            public void IsPositiveFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegative(value));
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-84)]
            [TestCase(int.MinValue)]
            public void IsNegativeOrZeroInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNegative(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-0.0000000000000001f)]
            [TestCase(-4932f)]
            [TestCase(float.MinValue)]
            public void IsNegativeFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNegative(value));
            }
        }

        [TestFixture]
        public class IsNegativeOrZero
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsZero_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.IsNegativeOrZero(0));
                Assert.DoesNotThrow(() => _bouncer.IsNegativeOrZero(0f));
            }

            [Test]
            [TestCase(1)]
            [TestCase(7)]
            [TestCase(int.MaxValue)]
            public void IsPositiveInt_ThenThrowException(int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegativeOrZero(value));
            }

            [Test]
            [TestCase(1f)]
            [TestCase(271f)]
            [TestCase(float.MaxValue)]
            [TestCase(0.000000000001f)]
            public void IsPositiveFloat_ThenThrowException(float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsNegativeOrZero(value));
            }


            [Test]
            [TestCase(-1)]
            [TestCase(-84)]
            [TestCase(int.MinValue)]
            public void IsNegativeInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNegativeOrZero(value));
            }

            [Test]
            [TestCase(-1f)]
            [TestCase(-0.0000000000000001f)]
            [TestCase(-4932f)]
            [TestCase(float.MinValue)]
            public void IsNegativeFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNegativeOrZero(value));
            }
        }

        [TestFixture]
        public class IsNotEmpty
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotEmpty(null));
            }

            [Test]
            [TestCaseSource(nameof(IsNotEmptyTestCaseData))]
            public void IsNotEmpty_ThenDoNothing(ICollection value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotEmpty(value));
            }

            [Test]
            [TestCaseSource(nameof(IsEmptyTestCaseData))]
            public void IsEmpty_ThenThrowException(ICollection value)
            {
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotEmpty(value));
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
        public class IsNotNullOrEmptyOnCollection
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsNotNullOrEmpty(null));
            }

            [Test]
            [TestCaseSource(nameof(IsNotEmptyTestCaseData))]
            public void IsNotEmpty_ThenDoNothing(ICollection value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsNotNullOrEmpty(value));
            }

            [Test]
            [TestCaseSource(nameof(IsEmptyTestCaseData))]
            public void IsEmpty_ThenThrowException(ICollection value)
            {
                Assert.Throws<ArgumentEmptyException>(() => _bouncer.IsNotNullOrEmpty(value));
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
        public class IsEmpty
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void IsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _bouncer.IsEmpty(null));
            }

            [Test]
            [TestCaseSource(nameof(IsEmptyTestCaseData))]
            public void IsEmpty_ThenDoNothing(ICollection value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsEmpty(value));
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

            [Test]
            [TestCaseSource(nameof(IsNotEmptyTestCaseData))]
            public void IsNotEmpty_ThenThrowException(ICollection value)
            {
                Assert.Throws<ArgumentNotEmptyException>(() => _bouncer.IsEmpty(value));
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
        }

        public class IsWithinRangeInt
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            [TestCase(0, -1, 0)]
            [TestCase(4223, -4224, 0)]
            [TestCase(5, 2, 0)]
            public void InvalidBoundariesInt_ThenThrowException(int min, int max, int value)
            {
                Assert.Throws<InvalidOperationException>(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0, 2, 1)]
            [TestCase(-3, -1, -2)]
            [TestCase(-1, 1, 0)]
            [TestCase(-2324234, 2, 1)]
            [TestCase(-500, -100, -234)]
            [TestCase(3429434, int.MaxValue, int.MaxValue - 1)]
            public void IsWithinRangeInt_ThenDoNothing(int min, int max, int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0, 2, 8)]
            [TestCase(-3, -1, -7)]
            [TestCase(-1, 1, 5)]
            [TestCase(-2324234, 2, 456773)]
            [TestCase(-500, -100, 234)]
            [TestCase(3429434, int.MaxValue, 0)]
            public void IsNotWithinRangeInt_ThenDoNothing(int min, int max, int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0, 0, 0)]
            [TestCase(0, 1, 0)]
            [TestCase(0, 1, 1)]
            [TestCase(-26, 48, -26)]
            [TestCase(-26, 48, 48)]
            public void ValueIsOnBoundariesInt_ThenDoNothing(int min, int max, int value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsWithinRange(min, max, value));
            }
        }

        [TestFixture]
        public class IsWithinRangeFloat
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            [TestCase(0f, -1f, 0f)]
            [TestCase(4223f, -4224f, 0f)]
            [TestCase(5f, 2f, 0f)]
            public void InvalidBoundariesFloat_ThenThrowException(float min, float max, float value)
            {
                Assert.Throws<InvalidOperationException>(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0f, 2f, 1f)]
            [TestCase(-3f, -1f, -2f)]
            [TestCase(-1f, 1f, 0f)]
            [TestCase(-2324234f, 2f, 1f)]
            [TestCase(-500f, -100f, -234f)]
            [TestCase(3429434f, float.MaxValue, float.MaxValue - 1f)]
            public void IsWithinRangeFloat_ThenDoNothing(float min, float max, float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0f, 2f, 8f)]
            [TestCase(-3f, -1f, -7f)]
            [TestCase(-1f, 1f, 5f)]
            [TestCase(-2324234f, 2f, 456773f)]
            [TestCase(-500f, -100f, 234f)]
            [TestCase(3429434f, float.MaxValue, 0f)]
            public void IsNotWithinRangeFloat_ThenDoNothing(float min, float max, float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsWithinRange(min, max, value));
            }

            [Test]
            [TestCase(0f, 0f, 0f)]
            [TestCase(0f, 1f, 0f)]
            [TestCase(0f, 1f, 1f)]
            [TestCase(-26f, 48f, -26f)]
            [TestCase(-26f, 48f, 48f)]
            public void ValueIsOnBoundariesFloat_ThenDoNothing(float min, float max, float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsWithinRange(min, max, value));
            }
        }

        [TestFixture]
        public class IsWithinRangeExcludingBoundaries
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            [TestCase(0f, -1f, 0f)]
            [TestCase(4223f, -4224f, 0f)]
            [TestCase(5f, 2f, 0f)]
            public void InvalidBoundariesFloat_ThenThrowException(float min, float max, float value)
            {
                Assert.Throws<InvalidOperationException>(() =>
                    _bouncer.IsWithinRangeExcludingBoundaries(min, max, value));
            }

            [Test]
            [TestCase(0f, 2f, 1f)]
            [TestCase(-3f, -1f, -2f)]
            [TestCase(-1f, 1f, 0f)]
            [TestCase(-2324234f, 2f, 1f)]
            [TestCase(-500f, -100f, -234f)]
            public void IsWithinRangeFloat_ThenDoNothing(float min, float max, float value)
            {
                Assert.DoesNotThrow(() => _bouncer.IsWithinRangeExcludingBoundaries(min, max, value));
            }

            [Test]
            [TestCase(0f, 2f, 8f)]
            [TestCase(-3f, -1f, -7f)]
            [TestCase(-1f, 1f, 5f)]
            [TestCase(-2324234f, 2f, 456773f)]
            [TestCase(-500f, -100f, 234f)]
            [TestCase(3429434f, float.MaxValue, 0f)]
            public void IsNotWithinRangeFloat_ThenDoNothing(float min, float max, float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    _bouncer.IsWithinRangeExcludingBoundaries(min, max, value));
            }

            [Test]
            [TestCase(0f, 0f, 0f)]
            [TestCase(0f, 1f, 0f)]
            [TestCase(0f, 1f, 1f)]
            [TestCase(-26f, 48f, -26f)]
            [TestCase(-26f, 48f, 48f)]
            public void ValueIsOnBoundariesFloat_ThenThrowException(float min, float max, float value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                    _bouncer.IsWithinRangeExcludingBoundaries(min, max, value));
            }
        }

        [TestFixture]
        public class Contains
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void NoExpectedValues_ThenThrowException()
            {
                Assert.Throws<InvalidOperationException>(() => _bouncer.Contains(new int[0], 5));
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
            public void IsAnExpectedValue_ThenDoNothing(int[] possibleValues, int value)
            {
                Assert.DoesNotThrow(() => _bouncer.Contains(possibleValues, value));
            }

            [Test]
            [TestCase(new[] {0}, 1)]
            [TestCase(new[] {-5}, 5)]
            [TestCase(new[] {8}, 0)]
            [TestCase(new[] {0, 2}, 1)]
            [TestCase(new[] {0, 1}, 2)]
            [TestCase(new[] {0, -5, 8, 13}, 5)]
            [TestCase(new[] {0, 0, 0, 0, 0}, 1)]
            public void IsNotAnExpectedValue_ThenThrowException(int[] possibleValues, int value)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.Contains(possibleValues, value));
            }
        }

        [TestFixture]
        public class IsGreater
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            [TestCase(1, 0)]
            [TestCase(-2, -10)]
            [TestCase(int.MaxValue, int.MinValue)]
            public void IsGreater_ThenDoNothing(int value, int other)
            {
                Assert.DoesNotThrow(() => _bouncer.IsGreater(value, other));
            }

            [Test]
            [TestCase(1, 2)]
            [TestCase(-11, -10)]
            [TestCase(int.MinValue, int.MaxValue)]
            public void IsNotGreater_ThenThrowException(int value, int other)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsGreater(value, other));
            }

            [Test]
            public void IsEqual_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsGreater(2, 2));
            }
        }

        [TestFixture]
        public class IsGreaterOrEqual
        {
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            [TestCase(1, 0)]
            [TestCase(-2, -10)]
            [TestCase(int.MaxValue, int.MinValue)]
            public void IsGreater_ThenDoNothing(int value, int other)
            {
                Assert.DoesNotThrow(() => _bouncer.IsGreaterOrEqual(value, other));
            }

            [Test]
            [TestCase(1, 2)]
            [TestCase(-11, -10)]
            [TestCase(int.MinValue, int.MaxValue)]
            public void IsNotGreater_ThenThrowException(int value, int other)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => _bouncer.IsGreaterOrEqual(value, other));
            }

            [Test]
            public void IsEqual_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.IsGreaterOrEqual(2, 2));
            }
        }

        [TestFixture]
        public class Singleton
        {
            [Test]
            public void IsFalse_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => BrutalHack.Bouncer.Bouncer.Instance.IsTrue(false));
            }

            [Test]
            public void IsTrue_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => BrutalHack.Bouncer.Bouncer.Instance.IsTrue(true));
            }
        }
    }
}