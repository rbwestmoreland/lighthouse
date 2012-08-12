using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lighthouse.Web.Models.Dashboard;
using Xunit;

namespace Test.Lighthouse.Web.Models.Dashboard
{
    public class BuildTests
    {
        public class ConstructorTests
        {
            [Fact]
            public void WhenParameterless_ShouldDefaultTo()
            {
                var build = new Build();

                Assert.Equal(null, build.CommitId);
                Assert.Equal(null, build.CommitMessage);
                Assert.Equal(null, build.Created);
                Assert.Equal(null, build.Deployed);
                Assert.Equal(null, build.DownloadUrl);
                Assert.Equal(null, build.Status);
                Assert.Equal(null, build.TestsUrl);
                Assert.Equal(null, build.Url);
            }
        }

        public class IsSuccessfulTests
        {
            [Fact]
            public void WhenStatusIsNull_ShouldReturnFalse()
            {
                var build = new Build();

                var actual = build.IsSuccessful();

                Assert.Equal(false, actual);
            }

            [Fact]
            public void WhenStatusIsNotSucceeded_ShouldReturnFalse()
            {
                var build = new Build();
                build.Status = "status";

                var actual = build.IsSuccessful();

                Assert.Equal(false, actual);
            }

            [Fact]
            public void WhenStatusIsSucceeded_ShouldReturnTrue()
            {
                var build = new Build();
                build.Status = "succeeded";

                var actual = build.IsSuccessful();

                Assert.Equal(true, actual);
            }

            [Fact]
            public void WhenStatusIsSucceededWithMixedCase_ShouldReturnTrue()
            {
                var build = new Build();
                build.Status = "SuCcEeDeD";

                var actual = build.IsSuccessful();

                Assert.Equal(true, actual);
            }
        }
    }
}
