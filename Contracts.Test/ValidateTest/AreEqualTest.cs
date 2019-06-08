using System;
using System.Collections.Generic;
using BrutalHack.Contracts;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Contracts.Test.ValidateTest
{
    public partial class ValidateTest
    {
        [TestFixture]
        public class AreEqual
        {
            [Test]
            public void NullAndNull_ThenDoNothing()
            {
                Assert.DoesNotThrow(() => Validate.AreEqual(null, null));
            }

            [Test]
            [TestCase(0)]
            [TestCase(6)]
            [TestCase(-2381)]
            [TestCase(int.MaxValue)]
            public void AreEqualInt_ThenDoNothing(int value)
            {
                Assert.DoesNotThrow(() => Validate.AreEqual(value, value));
            }

            [Test]
            [TestCase(0f)]
            [TestCase(6f)]
            [TestCase(-2381f)]
            [TestCase(float.MaxValue)]
            public void AreEqualFloat_ThenDoNothing(float value)
            {
                Assert.DoesNotThrow(() => Validate.AreEqual(value, value));
            }
            
            [Test]
            [TestCaseSource(nameof(AreEqualObjectTestData))]
            public void AreEqualObject_ThenThrowException(AreEqualObjectTestCase testCaseData)
            {
                Assert.DoesNotThrow(() => Validate.AreEqual(testCaseData.Value, testCaseData.Value));
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
                Assert.Throws<ArgumentException>(() => Validate.AreEqual(expected, value));
            }

            [Test]
            [TestCase(0f, 1f)]
            [TestCase(1f, 0f)]
            [TestCase(0.00000001f, 0.1f)]
            [TestCase(float.MinValue, float.MaxValue)]
            [TestCase(45351f, 398f)]
            [TestCase(-45351f, -398f)]
            public void AreNotEqualFloat_ThenThrowException(float expected, float value)
            {
                Assert.Throws<ArgumentException>(() => Validate.AreEqual(expected, value));
            }

            [Test]
            [TestCaseSource(nameof(AreNotEqualObjectTestData))]
            public void AreNotEqualObject_ThenThrowException(AreNotEqualObjectTestCase testCaseData)
            {
                Assert.Throws<ArgumentException>(() => Validate.AreEqual(testCaseData.Expected, testCaseData.Value));
            }

            public class AreNotEqualObjectTestCase
            {
                public object Expected;
                public object Value;
            }

            public static IEnumerable<object> AreNotEqualObjectTestData
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