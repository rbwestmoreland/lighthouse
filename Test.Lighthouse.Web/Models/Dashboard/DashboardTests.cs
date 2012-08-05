using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using LighthouseWebModels = Lighthouse.Web.Models.Dashboard;

namespace Test.Lighthouse.Web.Models.Dashboard
{
    public class DashboardTests
    {
        public class ConstructorTests
        {
            [Fact]
            public void WhenParameterless_ShouldDefaultTo()
            {
                var dashboard = new LighthouseWebModels.Dashboard();

                Assert.Equal(0, dashboard.Applications.Count());
            }
        }
    }
}
