using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lighthouse.Web.Models.Dashboard;
using Xunit;

namespace Test.Lighthouse.Web.Models.Dashboard
{
    public class ApplicationTests
    {
        public class ConstructorTests
        {
            [Fact]
            public void WhenParameterless_ShouldDefaultTo()
            {
                var application = new Application();

                Assert.Equal(0, application.Builds.Count());
                Assert.Equal(null, application.Name);
                Assert.Equal(null, application.Slug);
                Assert.Equal(null, application.Url);
            }
        }

        public class GetQueuedBuildsTests
        {
            [Fact]
            public void WhenHas0Builds_ShouldReturn0QueuedBuilds()
            {
                var application = new Application();

                var actual = application.GetQueuedBuilds();

                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas0QueuedBuilds_ShouldReturn0QueuedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetQueuedBuilds();

                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas1QueuedBuilds_ShouldReturn1QueuedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "queued"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetQueuedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1QueuedBuildsWithMixedCaseStatus_ShouldReturn1QueuedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "QuEuEd"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetQueuedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1QueuedBuildAnd1OtherBuilds_ShouldReturn1QueuedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });
                builds.Add(new Build()
                {
                    Status = "queued"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetQueuedBuilds();

                Assert.Equal(1, actual.Count());
                Assert.Equal("queued", actual.First().Status);
            }
        }

        public class GetBuildingBuildsTests
        {
            [Fact]
            public void WhenHas0Builds_ShouldReturn0BuildingBuilds()
            {
                var application = new Application();

                var actual = application.GetBuildingBuilds();

                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas0BuildingBuilds_ShouldReturn0BuildingBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetBuildingBuilds();
                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas1BuildingBuilds_ShouldReturn1BuildingBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "building"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetBuildingBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1BuildingBuildsWithMixedCaseStatus_ShouldReturn1BuildingBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "BuIlDiNg"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetBuildingBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1BuildingBuildAnd1OtherBuilds_ShouldReturn1BuildingBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });
                builds.Add(new Build()
                {
                    Status = "building"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetBuildingBuilds();

                Assert.Equal(1, actual.Count());
                Assert.Equal("building", actual.First().Status);
            }
        }

        public class GetCompletedBuildsTests
        {
            [Fact]
            public void WhenHas0Builds_ShouldReturn0CompletedBuilds()
            {
                var application = new Application();

                var actual = application.GetCompletedBuilds();

                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas0CompletedBuilds_ShouldReturn0CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();
                Assert.Equal(0, actual.Count());
            }

            [Fact]
            public void WhenHas1SucceededBuilds_ShouldReturn1CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "succeeded"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1FailedBuilds_ShouldReturn1CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "failed"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1SucceededBuildsWithMixedCaseStatus_ShouldReturn1CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "SuCcEeDeD"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1FailedBuildsWithMixedCaseStatus_ShouldReturn1CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "FaIlEd"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();

                Assert.Equal(1, actual.Count());
            }

            [Fact]
            public void WhenHas1CompletedBuildAnd1OtherBuilds_ShouldReturn1CompletedBuilds()
            {
                var builds = new List<Build>();
                builds.Add(new Build()
                {
                    Status = "status"
                });
                builds.Add(new Build()
                {
                    Status = "failed"
                });

                var application = new Application();
                application.Builds = builds;

                var actual = application.GetCompletedBuilds();

                Assert.Equal(1, actual.Count());
                Assert.Equal("failed", actual.First().Status);
            }
        }
    }
}
