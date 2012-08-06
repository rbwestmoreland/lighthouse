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

        public class TimeRemainingTests
        {
            [Fact]
            public void WhenCreatedIsNull_ShouldReturnTimeSpanZero()
            {
                var build = new Build();

                var actual = build.TimeRemaining(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(TimeSpan.Zero, actual);
            }

            [Fact]
            public void WhenDeployedIsNotNull_ShouldReturnTimeSpanZero()
            {
                var build = new Build();
                build.Deployed = DateTime.UtcNow;

                var actual = build.TimeRemaining(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(TimeSpan.Zero, actual);
            }

            [Fact]
            public void WhenGivenTimeSpanZeroOrLess_ShouldReturnTimeSpanZero()
            {
                var build = new Build();
                build.Created = DateTime.UtcNow;

                var actual = build.TimeRemaining(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(TimeSpan.Zero, actual);
            }

            [Fact]
            public void WhenGivenUtcNowIsLessThanCreated_ShouldReturnTimeSpanZero()
            {
                var build = new Build();
                build.Created = DateTime.UtcNow;

                var actual = build.TimeRemaining(TimeSpan.Zero, DateTime.UtcNow.AddMinutes(-1));

                Assert.Equal(TimeSpan.Zero, actual);
            }

            [Fact]
            public void WhenStateAndAllParametersAreValid_ShouldReturnTimeRemaining()
            {
                var utcNow = DateTime.UtcNow;
                var created = utcNow.AddMinutes(-1);
                var averageBuildTime = new TimeSpan(0, 2, 0);

                var build = new Build();
                build.Created = created;

                var expected = new TimeSpan(0, 1, 0);
                var actual = build.TimeRemaining(averageBuildTime, utcNow);

                Assert.Equal(expected, actual);
            }
        }

        public class PercentCompleteTests
        {
            [Fact]
            public void WhenCreatedIsNull_ShouldReturn0()
            {
                var build = new Build();

                var actual = build.PercentComplete(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(0, actual);
            }

            [Fact]
            public void WhenDeployedIsNotNull_ShouldReturn100()
            {
                var build = new Build();
                build.Created = DateTime.UtcNow;
                build.Deployed = DateTime.UtcNow;

                var actual = build.PercentComplete(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(100, actual);
            }

            [Fact]
            public void WhenGivenTimeSpanZeroOrLess_ShouldReturn100()
            {
                var build = new Build();
                build.Created = DateTime.UtcNow;

                var actual = build.PercentComplete(TimeSpan.Zero, DateTime.UtcNow);

                Assert.Equal(100, actual);
            }

            [Fact]
            public void WhenGivenUtcNowIsLessThanCreated_ShouldReturn0()
            {
                var build = new Build();
                build.Created = DateTime.UtcNow;

                var actual = build.PercentComplete(new TimeSpan(0, 1, 0), DateTime.UtcNow.AddMinutes(-1));

                Assert.Equal(0, actual);
            }

            [Fact]
            public void WhenStateAndAllParametersAreValid_ShouldReturnPercentComplete()
            {
                var utcNow = DateTime.UtcNow;
                var created = utcNow.AddMinutes(-1);
                var averageBuildTime = new TimeSpan(0, 2, 0);

                var build = new Build();
                build.Created = created;

                var actual = build.PercentComplete(averageBuildTime, utcNow);

                Assert.Equal(50, actual);
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
