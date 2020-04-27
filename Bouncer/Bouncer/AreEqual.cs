using System;
using BrutalHack.Bouncer.Constants;

namespace BrutalHack.Bouncer
{
    public partial class Bouncer
    {
        /// <param name="expected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AreEqual(int expected, int value)
        {
            if (expected != value)
            {
                throw new ArgumentException($"Expected: {expected}, actual {value}.");
            }
        }

        public void AreEqual(object expected, object value)
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
        public void AreEqual(float expected, float value, float epsilon = Constant.Epsilon)
        {
            if (Math.Abs(expected - value) > epsilon)
            {
                throw new ArgumentException($"Expected: {expected}, actual {value}.");
            }
        }        
    }
}