#region Copyright (c) 2009 S. van Deursen
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

using System;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.DoesNotContain method.
    /// </summary>
    
    public class StringDoesNotContainTests
    {
        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should fail.")]
        public void DoesNotContainTest01()
        {
            string a = "test";
            Action action = () => Condition.Requires(a).DoesNotContain(a);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"es\"' should fail.")]
        public void DoesNotContainTest02()
        {
            string a = "test";
            Action action = () => Condition.Requires(a).DoesNotContain("es");
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain null' should pass.")]
        public void DoesNotContainTest03()
        {
            string a = "test";
            // A null value will never be found
            Condition.Requires(a).DoesNotContain(null);
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"\"' should fail.")]
        public void DoesNotContainTest04()
        {
            string a = "test";
            // An empty string will always be found
            Action action = () => Condition.Requires(a).DoesNotContain(String.Empty);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain \"\"' should pass.")]
        public void DoesNotContainTest05()
        {
            string a = null;
            // A null string only contains other null strings.
            Condition.Requires(a).DoesNotContain(String.Empty);
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (null) with 'x DoesNotContain null' should fail.")]
        public void DoesNotContainTest06()
        {
            string a = null;
            Action action = () => Condition.Requires(a).DoesNotContain(null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test me\"' should pass.")]
        public void DoesNotContainTest07()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("test me");
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain \"test\"' should fail with a correct exception message.")]
        public void DoesNotContainTest08()
        {
            string expectedMessage =
                "a should not contain 'test'." + Environment.NewLine +
                TestHelper.CultureSensitiveArgumentExceptionParameterText + ": a";

            try
            {
                string a = "test";
                Condition.Requires(a, "a").DoesNotContain("test");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        [Description("Calling DoesNotContain with conditionDescription parameter should pass.")]
        public void DoesNotContainTest09()
        {
            string a = "test";
            Condition.Requires(a).DoesNotContain("test me", string.Empty);
        }

        [Fact]
        [Description("Calling a failing DoesNotContain should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void DoesNotContainTest10()
        {
            string a = "test me";
            try
            {
                Condition.Requires(a, "a").DoesNotContain("test", "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling DoesNotContain on string x (\"test\") with 'x DoesNotContain x' should succeed when exceptions are suppressed.")]
        public void DoesNotContainTest11()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().DoesNotContain(a);
        }
    }
}