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
using System.Collections;
using System.Collections.Generic;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsLongerOrEqual method.
    /// </summary>
    
    public class CollectionIsLongerOrEqualTests
    {
        [Fact]
        
        [Description("Calling IsLongerOrEqual(1) with a collection containing no elements should fail.")]
        public void CollectionIsLongerOrEqualTest01()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Action a = () => Condition.Requires(set).IsLongerOrEqual(1);
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest02()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsLongerOrEqual(0);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(-1) with a collection containing no elements should pass.")]
        public void CollectionIsLongerOrEqualTest03()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).IsLongerOrEqual(-1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest04()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsLongerOrEqual(1);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) with a collection containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest05()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int> { 1 };

            Condition.Requires(set).IsLongerOrEqual(0);
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with an ArrayList containing one element should pass.")]
        public void CollectionIsLongerOrEqualTest06()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Condition.Requires(list).IsLongerOrEqual(1);
        }

        [Fact]
        
        [Description("Calling IsLongerOrEqual(2) with an ArrayList containing one element should fail.")]
        public void CollectionIsLongerOrEqualTest07()
        {
            // ArrayList implements ICollection.
            ArrayList list = new ArrayList { 1 };

            Action a = () => Condition.Requires(list).IsLongerOrEqual(2);
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(0) on a null reference should pass.")]
        public void CollectionIsLongerOrEqualTest08()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerOrEqual(0);
        }

        [Fact]
        
        [Description("Calling IsLongerOrEqual(1) on a null reference should fail.")]
        public void CollectionIsLongerOrEqualTest09()
        {
            IEnumerable list = null;

            Action a = () => Condition.Requires(list).IsLongerOrEqual(1);
            a.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling IsLongerOrEqual with the condtionDescription parameter should pass.")]
        public void CollectionIsLongerOrEqualTest10()
        {
            IEnumerable list = null;

            Condition.Requires(list).IsLongerOrEqual(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLongerOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void CollectionIsLongerOrEqualTest11()
        {
            IEnumerable list = null;
            try
            {
                Condition.Requires(list, "list").IsLongerOrEqual(1, "abc {0} def");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc list def"));
            }
        }

        [Fact]
        [Description("Calling IsLongerOrEqual(1) with a collection containing no elements should succeed when exceptions are suppressed.")]
        public void CollectionIsLongerOrEqualTest12()
        {
            // HashSet only implements generic ICollection<T>, no ICollection.
            HashSet<int> set = new HashSet<int>();

            Condition.Requires(set).SuppressExceptionsForTest().IsLongerOrEqual(1);
        }
    }
}