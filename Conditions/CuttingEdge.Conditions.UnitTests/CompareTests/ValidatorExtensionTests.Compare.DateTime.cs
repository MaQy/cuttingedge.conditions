﻿#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'DateTime'.
using System;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    
    public class CompareDateTimeTests
    {
        private static readonly DateTime One = new DateTime(2000, 1, 1);
        private static readonly DateTime Two = new DateTime(2000, 1, 2);
        private static readonly DateTime Three = new DateTime(2000, 1, 3);
        private static readonly DateTime Four = new DateTime(2000, 1, 4);
        private static readonly DateTime Five = new DateTime(2000, 1, 5);

        #region IsDateTimeInRange

        [Fact]
        
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should fail.")]
        public void IsDateTimeInRangeTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsInRange(Two, Four);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsInRange on DateTime x with 'lower bound = x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x < upper bound' should pass.")]
        public void IsDateTimeInRangeTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on DateTime x with 'lower bound < x = upper bound' should pass.")]
        public void IsDateTimeInRangeTest04()
        {
            DateTime a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        
        [Description("Calling IsInRange on DateTime x with 'lower bound < x > upper bound' should fail.")]
        public void IsDateTimeInRangeTest05()
        {
            DateTime a = Five;
            Action action = () => Condition.Requires(a).IsInRange(Two, Four);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsInRange on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeInRangeTest06()
        {
            DateTime a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeInRangeTest07()
        {
            DateTime a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsInRange on DateTime x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeInRangeTest08()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsDateTimeInRange

        #region IsDateTimeNotInRange

        [Fact]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound > x < upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();

        }

        [Fact]
        
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x < upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x = upper bound' should fail.")]
        public void IsDateTimeNotInRangeTest04()
        {
            DateTime a = Four;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound < x > upper bound' should pass.")]
        public void IsDateTimeNotInRangeTest05()
        {
            DateTime a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotInRangeTest06()
        {
            DateTime a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotInRangeTest07()
        {
            DateTime a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotInRange on DateTime x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotInRangeTest08()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsDateTimeNotInRange

        #region IsDateTimeGreaterThan

        [Fact]
        
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should fail.")]
        public void IsDateTimeGreaterThanTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeGreaterThanTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeGreaterThanTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeGreaterThanTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterThan on DateTime x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsDateTimeGreaterThanTest06()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsDateTimeGreaterThan

        #region IsDateTimeNotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeNotGreaterThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        
        [Description("Calling IsNotGreaterThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterThanTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsNotGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotGreaterThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotGreaterThanTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on DateTime x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotGreaterThanTest06()
        {
            DateTime a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsDateTimeNotGreaterThan

        #region IsDateTimeGreaterOrEqual

        [Fact]
        
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeGreaterOrEqualTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeGreaterOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeGreaterOrEqualTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeGreaterOrEqualTest05()
        {
            DateTime a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on DateTime x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDateTimeGreaterOrEqualTest06()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsDateTimeGreaterOrEqual

        #region IsDateTimeNotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeNotGreaterOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsNotGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeNotGreaterOrEqualTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsNotGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotGreaterOrEqualTest04()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotGreaterOrEqualTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on DateTime x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotGreaterOrEqualTest06()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsDateTimeNotGreaterOrEqual

        #region IsDateTimeLessThan

        [Fact]
        [Description("Calling IsLessThan on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessThanTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should fail.")]
        public void IsDateTimeLessThanTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsLessThan on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessThanTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsLessThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeLessThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeLessThanTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessThan on DateTime x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeLessThanTest06()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsDateTimeLessThan

        #region IsDateTimeNotLessThan

        [Fact]
        
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessThanTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsNotLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound = x' should pass.")]
        public void IsDateTimeNotLessThanTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessThanTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotLessThanTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotLessThanTest05()
        {
            DateTime a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotLessThan on DateTime x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotLessThanTest06()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsDateTimeNotLessThan

        #region IsDateTimeLessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on DateTime x with 'x < upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on DateTime x with 'x = upper bound' should pass.")]
        public void IsDateTimeLessOrEqualTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        
        [Description("Calling IsLessOrEqual on DateTime x with 'x > upper bound' should fail.")]
        public void IsDateTimeLessOrEqualTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsLessOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeLessOrEqualTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeLessOrEqualTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessOrEqual on DateTime x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsDateTimeLessOrEqualTest06()
        {
            DateTime a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsDateTimeLessOrEqual

        #region IsDateTimeNotLessOrEqual

        [Fact]
        
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound > x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsNotLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound = x' should fail.")]
        public void IsDateTimeNotLessOrEqualTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsNotLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound < x' should pass.")]
        public void IsDateTimeNotLessOrEqualTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotLessOrEqualTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotLessOrEqualTest05()
        {
            DateTime a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on DateTime x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotLessOrEqualTest06()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsDateTimeEqualTo

        [Fact]
        
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should fail.")]
        public void IsDateTimeEqualToTest01()
        {
            DateTime a = One;
            Action action = () => Condition.Requires(a).IsEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsEqualTo on DateTime x with 'x = other' should pass.")]
        public void IsDateTimeEqualToTest02()
        {
            DateTime a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        
        [Description("Calling IsEqualTo on DateTime x with 'x > other' should fail.")]
        public void IsDateTimeEqualToTest03()
        {
            DateTime a = Three;
            Action action = () => Condition.Requires(a).IsEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsEqualTo on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeEqualToTest04()
        {
            DateTime a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsEqualTo on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeEqualToTest05()
        {
            DateTime a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsEqualTo on DateTime x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsDateTimeEqualToTest06()
        {
            DateTime a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsDateTimeEqualTo

        #region IsDateTimeNotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on DateTime x with 'x < other' should pass.")]
        public void IsDateTimeNotEqualToTest01()
        {
            DateTime a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should fail.")]
        public void IsDateTimeNotEqualToTest02()
        {
            DateTime a = Two;
            Action action = () => Condition.Requires(a).IsNotEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotEqualTo on DateTime x with 'x > other' should pass.")]
        public void IsDateTimeNotEqualToTest03()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on DateTime x with conditionDescription should pass.")]
        public void IsDateTimeNotEqualToTest04()
        {
            DateTime a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on DateTime should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDateTimeNotEqualToTest05()
        {
            DateTime a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotEqualTo on DateTime x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsDateTimeNotEqualToTest06()
        {
            DateTime a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsDateTimeNotEqualTo
    }
}