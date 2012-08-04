using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lighthouse.Web.Models.Dashboard
{
    public class Application
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public IEnumerable<Build> Builds { get; set; }

        public string GetCurrentStatus()
        {
            if (Builds != null && Builds.Any())
            {
                return Builds.First().Status.ToLower();
            }
            else
            {
                return "no builds";
            }
        }

        public TimeSpan AverageBuildTime()
        {
            var averageBuildTime = TimeSpan.Zero;

            if (Builds != null && Builds.Any())
            {
                var completedBuilds = Builds.Where(b => b.Created.HasValue && b.Deployed.HasValue);
                if (completedBuilds.Any())
                {
                    var averageBuildSeconds = completedBuilds.Average(b => (b.Deployed.Value - b.Created.Value).TotalSeconds);
                    var roundedUpAverageBuildSeconds = (int)Math.Round(averageBuildSeconds, MidpointRounding.AwayFromZero);
                    averageBuildTime = new TimeSpan(0, 0, roundedUpAverageBuildSeconds);
                }
            }

            return averageBuildTime;
        }
    }
}