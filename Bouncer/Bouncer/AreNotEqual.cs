using System;
using System.Collections;
using System.Linq;
using BrutalHack.Bouncer.Constants;
using BrutalHack.Bouncer.Exceptions;

namespace BrutalHack.Bouncer
{
    public partial class Bouncer
    {
        /// <param name="notExpected"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AreNotEqual(int notExpected, int value)
        {
            if (notExpected == value)
            {
                throw new ArgumentException($"Value was not expected to be: {notExpected}, actual {value}.");
            }
        }

        public void AreNotEqual(object notExpected, object value)
        {
            if (notExpected == null)
            {
                if (value == null)
                {
                    throw new ArgumentException($"Value was not expected to be: {null}.");
                }

                return;
            }

            if (notExpected.Equals(value))
            {
                throw new ArgumentException($"Value was not expected to be: {notExpected}, actual {value}.");
            }
        }

        /// <param name="notExpected"></param>
        /// <param name="value"></param>
        /// <param name="epsilon"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AreNotEqual(float notExpected, float value, float epsilon = Constant.Epsilon)
        {
            if (Math.Abs(notExpected - value) <= epsilon)
            {
                throw new ArgumentException(
                    $"Value was not expected to be: {notExpected}, actual {value}. Using epsilon {epsilon}");
            }
        }
    }
}