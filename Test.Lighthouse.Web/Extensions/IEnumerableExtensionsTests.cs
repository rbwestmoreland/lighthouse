using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Test.Lighthouse.Web.Extensions
{
    public class IEnumerableExtensionsTests
    {
        public class IsNotNullAndNotEmptyTests
        {
            [Fact]
            public void WhenIsNull_ShouldReturnFalse()
            {
                #pragma warning disable 1720
                var actual = default(IEnumerable<object>).IsNotNullAndNotEmpty();
                #pragma warning restore 1720

                Assert.False(actual);
            }

            [Fact]
            public void WhenHasNoElements_ShouldReturnFalse()
            {
                var actual = new List<object>().IsNotNullAndNotEmpty();

                Assert.False(actual);
            }

            [Fact]
            public void WhenHasElements_ShouldReturnTrue()
            {
                var enumerable = new List<object>();
                enumerable.Add(new { });
                var actual = enumerable.IsNotNullAndNotEmpty();

                Assert.True(actual);
            }
        }

        public class IsNullOrEmptyTests
        {
            [Fact]
            public void WhenIsNull_ShouldReturnTrue()
            {
                #pragma warning disable 1720
                var actual = default(IEnumerable<object>).IsNullOrEmpty();
                #pragma warning restore 1720

                Assert.True(actual);
            }

            [Fact]
            public void WhenHasNoElements_ShouldReturnTrue()
            {
                var actual = new List<object>().IsNullOrEmpty();

                Assert.True(actual);
            }

            [Fact]
            public void WhenHasElements_ShouldReturnFalse()
            {
                var enumerable = new List<object>();
                enumerable.Add(new { });
                var actual = enumerable.IsNullOrEmpty();

                Assert.False(actual);
            }
        }
    }
}
