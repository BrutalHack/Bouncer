using System;
using System.Collections.Generic;
using BrutalHack.Bouncer;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Bouncer.Test.BouncerTest
{
    public partial class BouncerTest
    {
        [TestFixture]
        public class AreEqual
        {
            private const float CustomEpsilon = 0.1f;
            private IBouncer _bouncer;

            [SetUp]
            public void SetUp()
            {
                _bouncer = new BrutalHack.Bouncer.Bouncer();
            }

            [Test]
            public void NullAndNull_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => _bouncer.AreEqual(null, null));
            }

            [Test]
            [TestCase(0)]
            [TestCase(6)]
            [TestCase(-2381)]
            [TestCase(int.MaxValue)]
            public void AreEqualInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => _bouncer.AreEqual(value, value));
            }

            [Test]
            [TestCase(0f, 0f)]
            [TestCase(6f, 6f)]
            [TestCase(6f, 6.00005f)]
            [TestCase(-2381f, -2381f)]
            [TestCase(-2381f, -2381.00005f)]
            [TestCase(float.MaxValue, float.MaxValue)]
            [TestCase(float.MinValue, float.MinValue)]
            public void AreEqualFloat_ThenDoNothing(float expected, float value)
            {
                Assert.DoesNotThrow(() => _bouncer.AreEqual(expected, value));
            }

            [Test]
            [TestCase(0f, 0f)]
            [TestCase(6f, 6f)]
            [TestCase(6f, 6.05f)]
            [TestCase(-2381f, -2381f)]
            [TestCase(-2381f, -2381.05f)]
            [TestCase(float.MaxValue, float.MaxValue)]
            [TestCase(float.MinValue, float.MinValue)]
            public void AreEqualCustomFloat_ThenDoNothing(float expected, float value)
            {
                Assert.DoesNotThrow(() => _bouncer.AreEqual(expected, value, CustomEpsilon));
            }

            [Test]
            [TestCaseSource(nameof(AreEqualObjectTestData))]
            public void AreEqualObject_ThenDoNothing(AreEqualObjectTestCase testCaseData)
            {
                Assert.DoesNotThrow(() => _bouncer.AreEqual(testCaseData.Value, testCaseData.Value));
            }

            public class AreEqualObjectTestCase
            {
                public object Value;
            }

            public static IEnumerable<object> AreEqualObjectTestData
            {
                [UsedImplicitly]
                get
                {
                    var testCases = new List<AreEqualObjectTestCase>
                    {
                        new AreEqualObjectTestCase
                        {
                            Value = Guid.NewGuid()
                        },
                        new AreEqualObjectTestCase
                        {
                            Value = new Uri("http://localhost")
                        },
                        new AreEqualObjectTestCase
                        {
                            Value = "two"
                        },
                        new AreEqualObjectTestCase
                        {
                            Value = false
                        }
                    };

                    foreach (var testCase in testCases)
                    {
                        yield return testCase;
                    }
                }
            }

            [Test]
            [TestCase(0, 1)]
            [TestCase(1, 0)]
            [TestCase(int.MinValue, int.MaxValue)]
            [TestCase(45351, 398)]
            [TestCase(-45351, -398)]
            public void AreNotEqualInt_ThenThrowException(int expected, int value)
            {
                Assert.Throws<ArgumentException>(() => _bouncer.AreEqual(expected, value));
            }

            [Test]
            [TestCase(0f, 1f)]
            [TestCase(1f, 0f)]
            [TestCase(0.00000005f, 0.5f)]
            [TestCase(-0.00000005f, -0.5f)]
            [TestCase(45351f, 398f)]
            [TestCase(-45351f, -398f)]
            [TestCase(float.MinValue, float.MaxValue)]
            public void AreNotEqualFloat_ThenThrowException(float expected, float value)
            {
                Assert.Throws<ArgumentException>(() => _bouncer.AreEqual(expected, value));
            }

            [Test]
            [TestCase(0f, 1f)]
            [TestCase(1f, 0f)]
            [TestCase(0.5f, 0.7f)]
            [TestCase(-0.5f, -0.7f)]
            [TestCase(45351f, 398f)]
            [TestCase(-45351f, -398f)]
            [TestCase(float.MinValue, float.MaxValue)]
            public void AreNotEqualCustomFloat_ThenThrowException(float expected, float value)
            {
                Assert.Throws<ArgumentException>(() => _bouncer.AreEqual(expected, value, CustomEpsilon));
            }

            [Test]
            [TestCaseSource(nameof(AreNotEqualObjectTestData))]
            public void AreNotEqualObject_ThenThrowException(AreNotEqualObjectTestCase testCaseData)
            {
                Assert.Throws<ArgumentException>(() => _bouncer.AreEqual(testCaseData.Expected, testCaseData.Value));
            }

            public class AreNotEqualObjectTestCase
            {
                public object Expected;
                public object Value;
            }

            private static IEnumerable<object> AreNotEqualObjectTestData
            {
                [UsedImplicitly]
                get
                {
                    var testCases = new List<AreNotEqualObjectTestCase>
                    {
                        new AreNotEqualObjectTestCase
                        {
                            Expected = Guid.Empty,
                            Value = Guid.NewGuid()
                        },
                        new AreNotEqualObjectTestCase
                        {
                            Expected = new Uri("http://localhost"),
                            Value = new Uri("https://localhost")
                        },
                        new AreNotEqualObjectTestCase
                        {
                            Expected = "one",
                            Value = "two"
                        },
                        new AreNotEqualObjectTestCase
                        {
                            Expected = true,
                            Value = false
                        },
                        new AreNotEqualObjectTestCase
                        {
                            Expected = true,
                            Value = 5
                        },
                        new AreNotEqualObjectTestCase
                        {
                            Expected = null,
                            Value = "one"
                        }
                    };

                    foreach (var testCase in testCases)
                    {
                        yield return testCase;
                    }
                }
            }
        }
    }
}